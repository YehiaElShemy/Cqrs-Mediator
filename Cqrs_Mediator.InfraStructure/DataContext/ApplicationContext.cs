using Cqrs_Mediator_Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Cqrs_Mediator.InfraStructure.DataContext
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
