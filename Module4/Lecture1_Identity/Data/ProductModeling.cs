using Lecture1_Identity.Domain;
using Microsoft.EntityFrameworkCore;

namespace Lecture1_Identity.Data
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