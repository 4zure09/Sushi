using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sushi.Models
{
    public class Sushi
    {
        public int ID_Sushi { get; set; }
        public string Ten_Sushi { get; set; }
        public string Mota { get; set; }
        public float Gia { get; set; } 
        public string Hinh { get; set; }
    }
}