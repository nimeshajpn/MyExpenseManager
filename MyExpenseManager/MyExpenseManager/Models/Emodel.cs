using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MyExpenseManager.Models
{
    public class Emodel
    {
        [PrimaryKey] [AutoIncrement]
        public int ID { get; set; }
        public string Name     { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }
        public string Category { get; set; }    
        public string Type { get; set; }    

        public TimeSpan Time { get; set; }
    }
}
