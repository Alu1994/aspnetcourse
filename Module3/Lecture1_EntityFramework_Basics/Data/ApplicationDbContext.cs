using Lecture1_EntityFramework_Basics.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lecture1_EntityFramework_Basics.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            var categoria = new CategoryModeling(modelBuilder);
            var produto = new ProductModeling(modelBuilder);

            categoria.CriarModelo();
            produto.CriarModelo();
        }
    }
}