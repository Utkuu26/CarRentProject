using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracWebApp.Models
{
    public class Adminler
    {
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public Adminler()
        {
            Mail = "berfin@gmail.com";
            Sifre = "Berfin.123";
        }

    }
}