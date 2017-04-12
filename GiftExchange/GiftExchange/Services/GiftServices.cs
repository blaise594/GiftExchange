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
     public static void AddPresent(Present gift)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var text = (@"INSERT INTO dbo.Presents (Contents, GiftHint, ColorWrappingPaper, Height, Width, Depth, Weight, IsOpened)" + "Values (@conts, @hint, @paper, @howhigh, @howwide, @howdeep, @howheavy, @open)");

                var cmd = new SqlCommand(text, connection);

                cmd.Parameters.AddWithValue("@conts", gift.Contents);
                cmd.Parameters.AddWithValue("@hint", gift.GiftHint);
                cmd.Parameters.AddWithValue("@paper", gift.ColorWrappingPaper);
                cmd.Parameters.AddWithValue("@howhigh", gift.Height);
                cmd.Parameters.AddWithValue("@howwide", gift.Width);
                cmd.Parameters.AddWithValue("@howdeep", gift.Depth);
                cmd.Parameters.AddWithValue("@howheavy", gift.Weight);
                cmd.Parameters.AddWithValue("@open", gift.IsOpened);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            
        }
    }
}