using Amazon.Library.Models;

namespace Amazon.Library.Services
{
    public class InventoryServiceProxy
    {

        private int LastId
        {
            get { return Products.Any() ? Products.Select(c => c.Id).Max() : 1; }
        }

        private static readonly InventoryServiceProxy instance = new InventoryServiceProxy();
        private List<Product> products = new List<Product> { new Product { Id = 1, Name = "Ray-Ban", Description = "Sunglasses", Price = 49.99M, Quantity = 16 },
                                                             new Product { Id = 2, Name = "KitchenAid Set", Description = "Kitchenware set", Price = 27.49M, Quantity = 4 },
                                                             new Product { Id = 3, Name = "Bosch Spark Plugs", Description = "V6 sparkplugs", Price = 69.99M, Quantity = 300 },
                                                             new Product { Id = 4, Name = "Rocking Chair", Description = "Solid wood chair", Price = 49.99M, Quantity = 1 }};

        private InventoryServiceProxy() { }

        public static InventoryServiceProxy Instance
        {
            get { return instance; }
        }

        public List<Product> Products
        {
            get { return products; }
        }

        public void AddOrUpdate(Product product)
        {
            /*
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                products.Remove(existingProduct);
            }
            */
            var Add = false;

           

            if (product.Id == 0)
            {
           
                Add = true;
                product.Id = LastId + 1;
            }

            if (Add)
            {
                products.Add(product);
            }
        }

        public void Delete(int productId)
        {
            var productToRemove = products.FirstOrDefault(p => p.Id == productId);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }
        }

        public Product? Get(int pid)
        {
            return Products.FirstOrDefault(p => p.Id == pid);
        }

        public Product? GetbyName(string name)
        {
            return Products.FirstOrDefault(x => x.Name == name);
        }

    }
}

