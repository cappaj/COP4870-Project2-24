namespace Amazon.Library.Models
{
    public class Product
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool BuyOneGetOneFree { get; set; } // Use this for BOGO logic

        public Product(string name, string description, decimal price, int id, int quantity, bool buyOneGetOneFree = false)
        {
            Name = name;
            Description = description;
            Price = price;
            Id = id;
            Quantity = quantity;
            BuyOneGetOneFree = buyOneGetOneFree;
        }

        public Product(Product p)
        {
            Name = p.Name;
            Description = p.Description;
            Price = p.Price;
            Id = p.Id;
            Quantity = p.Quantity;
            BuyOneGetOneFree = p.BuyOneGetOneFree;
        }

        public Product() { }

        public override string ToString()
        {
            return $"{Id}. {Name}\t{Description}\t\t${Price}\t\t{Quantity}";
        }
    }

    public class Receipt
    {
        public List<ReceiptItem> Items { get; set; } = new List<ReceiptItem>();
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }

    public class ReceiptItem
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool Bogo { get; set; } 
        public decimal MarkdownAmount { get; set; }

        public decimal ItemTotal => (Quantity * Price) - (Quantity * MarkdownAmount);
    }
}
