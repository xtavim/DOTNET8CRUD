using CRUD_DotNet8.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CRUD_DotNet8.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        
            
        }

        public DbSet<User> Users { get; set; } 
    }
}
