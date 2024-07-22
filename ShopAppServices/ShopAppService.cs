using Sklep_internetowy.Modeles;

namespace Sklep_internetowy.ShopAppServices
{
    public class ShopAppService
    {
        private List<Product> Products = new List<Product>();

        
        public ShopAppService()
        {

            InitializeData();
        }

        public List<Product> GetAll()
        {
            return Products;
        }
        public Product GetElementById(long id)
        {
            return Products.Where(x => x.Id == id).FirstOrDefault();
        }
        private void InitializeData()
        {
            var product1 = new Product()
            {
                CategoryId = 1,
                CreationTime = DateTime.Now,
                Description = "Test1",
                Id = 1,
                IsActive = true,
                IsDelated = false,
                Name = "Test1",
                Price = 127.54
            };
            var product2 = new Product()
            {
                CategoryId = 1,
                CreationTime = DateTime.Now,
                Description = "Test2",
                Id = 2,
                IsActive = false,
                IsDelated = false,
                Name = "Test2",
                Price = 7.14
            };
            var product3 = new Product()
            {
                CategoryId = 1,
                CreationTime = DateTime.Now,
                Description = "Test3",
                Id = 3,
                IsActive = true,
                IsDelated = false,
                Name = "Test3",
                Price = 1241234789.41
            };
            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product3);

        }
    }
}
