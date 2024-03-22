using Cqrs_Mediator_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace Cqrs_Mediator.InfraStructure.DataContext
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
       

    }
}
