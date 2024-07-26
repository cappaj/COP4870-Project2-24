using Amazon.Library.Models;

namespace Amazon.Library.Services
{
    public class InventoryServiceProxy
    {
        private static readonly InventoryServiceProxy instance = new InventoryServiceProxy();
        private List<Product> products = new List<Product>();

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
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                products.Remove(existingProduct);
            }
            products.Add(product);
        }

        public void Delete(int productId)
        {
            var productToRemove = products.FirstOrDefault(p => p.Id == productId);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }
        }
    }
}

