using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Stored_Procedures
{
    public class UpdateQuery
    {
        public void UpdateGrant(string grantId, string grantName, decimal amount)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SWCCorp"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE [Grant] " +
                    "SET GrantName = @GrantName, " +
                    "Amount = @Amount " +
                    "WHERE GrantId = @GrantId";

                cmd.Parameters.AddWithValue("@GrantId", grantId);
                cmd.Parameters.AddWithValue("@GrantName", grantName);
                cmd.Parameters.AddWithValue("@Amount", amount);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
