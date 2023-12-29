using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;

namespace NTier_ECommerce_DAL.EFRepository
{
    public class EFActorsRepository : GenericRepository<Actors>, IActorsDAL
    {
        public EFActorsRepository(Context context) : base(context)
        {
            
        }
    }
}

/*  EXPLANATION
 
 The EFActorsRepository class is derived from the GenericRepository<Actors> class. This is a generic repository class that performs general database operations for the Actors type.

It also implements the IActorsDAL interface. The IActorsDAL interface is an interface that extends the GenericRepository<Actors> class and defines specific operations for the Actors type, specific to the general database operations provided by this class.

It is called in the constructor method of the class (EFActorsRepository(Context context)) by passing the context parameter to the constructor method of the parent class GenericRepository<Actors>. This allows the EFActorsRepository class to operate using a database context of type Context.*/