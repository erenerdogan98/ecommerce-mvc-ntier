using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public double Price { get; set; }
        public string MovieImageUrl { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }

        //Relations

        public List<Actors_Movie> Actors_Movies { get; set; }

        // for cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        // for procuder
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]

        public Producer Producer { get; set; }
    }
}
