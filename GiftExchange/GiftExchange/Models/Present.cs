using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GiftExchange.Models
{
    public class Present
    {
        public string Contents { get; set; }
        public string GiftHint { get; set; }
        public string ColorWrappingPaper { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Depth { get; set; }
        public double? Weight { get; set; }
        public bool? IsOpened { get; set; } = false;
        public int Id { get; set; }

        public Present()
        { }
        public Present(SqlDataReader reader)
        {
            this.Contents = reader["Contents"]?.ToString();
            this.GiftHint = reader["GiftHint"]?.ToString();
            this.ColorWrappingPaper = reader["ColorWrappingPaper"]?.ToString();
            this.Height = reader["Height"] as double?;
            this.Width = reader["Width"] as double?;
            this.Depth = reader["Depth"] as double?;
            this.Weight = reader["Weight"] as double?;
            this.IsOpened = reader["IsOpened"] as bool?;
            this.Id = (int)reader["Id"];
        }
    }
}