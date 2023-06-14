using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sushi.Models
{
    public class Lichsugiaodich
    {
        private readonly DataClasses1DataContext data;

        public Lichsugiaodich()
        {
            string connectionString = "Data Source=JIN-592G\\SQLEXPRESS;Initial Catalog=DACS;Integrated Security=True";
            data = new DataClasses1DataContext(connectionString);
        }
        public int mahd { set; get; }
        public string tensp { get; set; }
        public string hinhanh { get; set; }
        public string makh { set; get; }
        public string masp { get; set; }
        public int? iSoluong { get; set; }
        public decimal? tonggia { get; set; }
        public string ngaymua { get; set; }
    }
}