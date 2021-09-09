using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class ContactRepositoryADO : IContactRepository
    {
        public List<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Contact currentRow = new Contact();
                        currentRow.ContactId = Convert.ToByte(dr["ContactId"]);
                        currentRow.Name = dr["Name"].ToString();
                        currentRow.Message = dr["Message"].ToString();

                        if (dr["VINNumber"] != DBNull.Value)
                        {
                            currentRow.VINNumber = dr["VINNumber"].ToString();
                        }

                        if (dr["Email"] != DBNull.Value)
                        {
                            currentRow.Email = dr["Email"].ToString();
                        }

                        if (dr["Phone"] != DBNull.Value)
                        {
                            currentRow.Phone = dr["Phone"].ToString();
                        }

                        contacts.Add(currentRow);
                    }
                }
            }

            return contacts;
        }

        public void Insert(Contact newContact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactId", SqlDbType.TinyInt);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Name", newContact.Name);
                cmd.Parameters.AddWithValue("@Message", newContact.Message);

                if(string.IsNullOrEmpty(newContact.VINNumber))
                {
                    cmd.Parameters.AddWithValue("@VINNumber", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@VINNumber", newContact.VINNumber);
                }

                if (string.IsNullOrEmpty(newContact.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", newContact.Email);
                }

                if (string.IsNullOrEmpty(newContact.Phone))
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", newContact.Phone);
                }

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
