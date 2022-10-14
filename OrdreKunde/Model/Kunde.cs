﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OrdreKunde.Model
{
    public class Kunde
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        
        public string Age { get; set; }


        public string FullName { 
            get 
            {
                return LastName + "," + FirstName;
            }
        }
        public virtual List<Ordre> Ordre { get; set; }
    }
}

