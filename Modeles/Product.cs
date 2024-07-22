namespace Sklep_internetowy.Modeles
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public double Price { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDelated { get; set; }
        public bool IsActive { get; set; }

    }
}
