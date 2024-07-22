using Sklep_internetowy.Modeles;
using System.Data.SqlClient;

namespace Sklep_internetowy.ShopAppServices
{
    public class ShopAppService
    {
        private List<Product> Products = new List<Product>();
        private readonly string _ConnetionString;
        
        public ShopAppService(IConfiguration configuration)
        {
            _ConnetionString = "data source=DESKTOP-92RNAQI;initial catalog=SklepInternetowy;trusted_connection=true";
            //InitializeData();
        }

        public List<Product> GetAll()
        {
            var products = new List<Product>();
            using (var connetion = new SqlConnection(_ConnetionString))
            {
                var command = new SqlCommand("SELECT [Id],[Name],[Description],[CategoryId],[Price],[CreationTime],[IsDelated],[IsActive] FROM [SklepInternetowy].[dbo].[Product]", connetion);
                connetion.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = new Product()
                    {
                        Id = Convert.ToInt64(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        CategoryId = Convert.ToInt64(reader["CategoryId"]),
                        Price = Convert.ToDouble(reader["Price"]),
                        CreationTime = Convert.ToDateTime(reader["CreationTime"]),
                        IsDelated = Convert.ToBoolean(reader["IsDelated"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    };
                    products.Add(product);
                }
            }
            return products;
        }
        public Product GetElementById(long id)
        {
            
            var product = new Product();
            using (var connetion = new SqlConnection(_ConnetionString))
            {

                var command = new SqlCommand("SELECT [Id],[Name],[Description],[CategoryId],[Price],[CreationTime],[IsDelated],[IsActive] FROM [SklepInternetowy].[dbo].[Product] WHERE Id = @Id", connetion);
                command.Parameters.AddWithValue("Id", id);
                connetion.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    product = new Product()
                    {
                        Id = Convert.ToInt64(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        CategoryId = Convert.ToInt64(reader["CategoryId"]),
                        Price = Convert.ToDouble(reader["Price"]),
                        CreationTime = Convert.ToDateTime(reader["CreationTime"]),
                        IsDelated = Convert.ToBoolean(reader["IsDelated"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"])
                    };
                }
            }
            return product;
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
