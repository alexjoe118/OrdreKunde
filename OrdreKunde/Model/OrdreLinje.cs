using System;
namespace OrdreKunde.Model
{
    public class OrdreLinje
    {
        public int Id { get; set; }
        public int Antall { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Ordre Ordre { get; set; }
    }
}

