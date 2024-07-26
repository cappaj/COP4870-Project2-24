namespace Amazon.Library.Models
{
    public class ShoppingCart
    {
        public List<Product> Items { get; set; }

        public ShoppingCart()
        {
            Items = new List<Product>();
        }

        public void AddItem(Product product, int quantity) { }

        public void RemoveItem(int productId, int quantity) { }

        public string Checkout()
        {
            return "Receipt";
        }
    }
}

