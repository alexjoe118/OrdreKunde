using System;
using System.Collections.Generic;

namespace OrdreKunde.Model
{
    public class Stock
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public double Pris { get; set; }
        public virtual List<OrdreLinje> OrdreLinjer { get; set; }
    }
}

