using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_Entities
{
    public class Actors
    {
        [Key]
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string? ProfileUrl { get; set; }
        public string? Biography { get; set; }
    }
}
