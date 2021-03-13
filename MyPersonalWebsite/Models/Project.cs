using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalWebsite.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }

        [Display(Name = "Programmeer taal")]
        public string ProgrammeerTaal { get; set; }

        public string Omschrijving { get; set; }
    }
}