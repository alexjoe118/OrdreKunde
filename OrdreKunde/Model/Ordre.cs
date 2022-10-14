using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OrdreKunde.Model
{
    public class Ordre
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public string Dato { get; set; }
        public virtual Kunde Kunde { get; set; }
        public virtual List<OrdreLinje> OrdreLinjer { get; set; }
    }
}

