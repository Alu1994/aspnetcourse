using Lecture1_EntityFramework_Basics.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lecture1_EntityFramework_Basics.Data
{
    public class ProductModeling
    {
        private readonly ModelBuilder _modelo;
        public ProductModeling(ModelBuilder modelo)
        {
            _modelo = modelo;
        }

        public void CriarModelo(){
            _modelo.Entity<Product>().ToTable("Produto");
            _modelo.Entity<Product>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}