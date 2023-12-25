using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_DAL.Context
{
    public class Context : DbContext
    {
        string connectionString = "server = DESKTOP-57R498V\\SQLEXPRESS01;database = ntierecommerce; integrated security = true;TrustServerCertificate=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
