﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_Entities
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }

        // Relations
        public List<Movie> Movies { get; set; }
    }
}
