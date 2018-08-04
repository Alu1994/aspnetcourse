namespace Lecture1_EntityFramework_Basics.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }
    }
}