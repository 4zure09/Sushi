using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sushi.Models
{
    public class CTHDlst
    {
        private readonly DataClasses1DataContext db;

        public CTHDlst()
        {
            string connectionString = "Data Source=JIN-592G\\SQLEXPRESS;Initial Catalog=DACS;Integrated Security=True";
            db = new DataClasses1DataContext(connectionString);
        }
        public int Mahd { get; set; }
        public string tensp { get; set; }
        public int masp { get; set; }
        public int iSoluong { get; set; }
        public Double tonggia { get; set; }


        public CTHDlst(int idsanpham, int mahd)
        {
            Mahd = mahd;
            masp = idsanpham;
            Sushi sp = db.Sushis.SingleOrDefault(s => s.ID_Sushi == idsanpham);
            tensp = sp.TenSushi;
            tonggia = double.Parse(sp.Gia.ToString());
            iSoluong = 1;
        }

    }
}