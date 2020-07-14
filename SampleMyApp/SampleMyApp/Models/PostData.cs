using SQLite;
using System;

namespace SampleMyApp.Models
{
    public class PostData
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public int userId { get; set; }

        public string title { get; set; }

        public string body { get; set; }
      
    }

}
