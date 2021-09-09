using DvdLibraryWebApi.Data.Interfaces;
using DvdLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebApi.Data.ADO
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void Delete(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.Id = (int)dr["Id"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Rating"] != DBNull.Value)
                        {
                            dvd.Rating = dr["Rating"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }

                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public List<Dvd> GetByDirector(string director)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Director", director);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.Id = (int)dr["Id"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Rating"] != DBNull.Value)
                        {
                            dvd.Rating = dr["Rating"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }

                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public Dvd GetById(int id)
        {
            Dvd dvd = null; // Set to null in case it isn't found.

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd();
                        dvd.Id = (int)dr["Id"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Rating"] != DBNull.Value)
                        {
                            dvd.Rating = dr["Rating"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }
                    }
                }
            }

            return dvd;
        }

        public List<Dvd> GetByRating(string rating)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rating", rating);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.Id = (int)dr["Id"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Rating"] != DBNull.Value)
                        {
                            dvd.Rating = dr["Rating"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }

                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public List<Dvd> GetByReleaseYear(int releaseYear)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectByReleaseYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.Id = (int)dr["Id"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Rating"] != DBNull.Value)
                        {
                            dvd.Rating = dr["Rating"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }

                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public List<Dvd> GetByTitle(string title)
        {
            List<Dvd> dvds = new List<Dvd>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", title);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.Id = (int)dr["Id"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];

                        if (dr["Rating"] != DBNull.Value)
                        {
                            dvd.Rating = dr["Rating"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }

                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public void Insert(Dvd newDvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", newDvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", newDvd.ReleaseYear);

                if (string.IsNullOrEmpty(newDvd.Rating))
                {
                    cmd.Parameters.AddWithValue("@Rating", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Rating", newDvd.Rating);
                }

                if (string.IsNullOrEmpty(newDvd.Director))
                {
                    cmd.Parameters.AddWithValue("@Director", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Director", newDvd.Director);
                }

                if (string.IsNullOrEmpty(newDvd.Notes))
                {
                    cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Notes", newDvd.Notes);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

                newDvd.Id = (int)param.Value;
            }
        }

        public void Update(Dvd updatedDvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", updatedDvd.Id);
                cmd.Parameters.AddWithValue("@Title", updatedDvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", updatedDvd.ReleaseYear);

                if (string.IsNullOrEmpty(updatedDvd.Rating))
                {
                    cmd.Parameters.AddWithValue("@Rating", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Rating", updatedDvd.Rating);
                }

                if (string.IsNullOrEmpty(updatedDvd.Director))
                {
                    cmd.Parameters.AddWithValue("@Director", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Director", updatedDvd.Director);
                }

                if (string.IsNullOrEmpty(updatedDvd.Notes))
                {
                    cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Notes", updatedDvd.Notes);
                }

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
