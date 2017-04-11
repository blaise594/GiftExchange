using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GiftExchange.Models;

namespace GiftExchange.Services
{
    public class GiftServices
    {
        const string connectionString = @"Server=localhost\SQLEXPRESS;Database=GiftExchange;Trusted_Connection=True;";
        public List<Present> GetAllPresents()
        {
            var rv = new List<Present>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Presents";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Present(reader));
                }
                connection.Close();
            }
            return rv;
        }
   
    }
}