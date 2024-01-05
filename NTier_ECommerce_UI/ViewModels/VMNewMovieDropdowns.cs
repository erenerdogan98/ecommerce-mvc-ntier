using NTier_ECommerce_Entities;

namespace NTier_ECommerce_UI.ViewModels
{
    public class VMNewMovieDropdowns
    {
        public VMNewMovieDropdowns()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actors>();
        }

        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actors> Actors { get; set; }
    }
}
/* 
    This type of ViewModel is usually created by a controller and used by a view. For example,
it can be used on a movie add page to offer the user the ability to choose from dropdown lists.
The Controller assigns the required data to the ViewModel and allows the user to make selections while this ViewModel is used by the View.
 */
