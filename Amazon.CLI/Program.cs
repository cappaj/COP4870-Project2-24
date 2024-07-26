using Amazon.Library.Models;
using Amazon.Library.Services;
using System;
using System.Linq;

namespace Amazon.CLI
{
    internal class Program
    {
        static InventoryServiceProxy inventoryService = InventoryServiceProxy.Instance;
        static ShoppingCartService shoppingCartService = ShoppingCartService.Instance;

        public static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("*** Main Menu ***");
                Console.WriteLine("1. Inventory Management");
                Console.WriteLine("2. Shop");
                Console.WriteLine("3. Exit\n");
                var x = Console.ReadLine() ?? string.Empty;

                if (x.Equals("1", StringComparison.InvariantCultureIgnoreCase))
                {
                    InventoryMenu();
                }
                else if (x.Equals("2", StringComparison.InvariantCultureIgnoreCase))
                {
                    ShopMenu();
                }
                else if (x.Equals("3", StringComparison.InvariantCultureIgnoreCase))
                {
                    run = false;
                }
                else
                {
                    Console.WriteLine("Invalid! Please try again.\n");
                }
            }
        }

        static void InventoryMenu()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("*** Inventory Management Menu ***");
                Console.WriteLine("1. Add Inventory Item");
                Console.WriteLine("2. Read Items in Inventory");
                Console.WriteLine("3. Update Items in Inventory");
                Console.WriteLine("4. Delete Item in Inventory");
                Console.WriteLine("5. Exit\n");
                var x = Console.ReadLine() ?? string.Empty;

                if (x.Equals("1", StringComparison.InvariantCultureIgnoreCase))
                {
                    AddInventoryItem();
                }
                else if (x.Equals("2", StringComparison.InvariantCultureIgnoreCase))
                {
                    ReadInventoryItems();
                }
                else if (x.Equals("3", StringComparison.InvariantCultureIgnoreCase))
                {
                    UpdateInventoryItem();
                }
                else if (x.Equals("4", StringComparison.InvariantCultureIgnoreCase))
                {
                    DeleteInventoryItem();
                }
                else if (x.Equals("5", StringComparison.InvariantCultureIgnoreCase))
                {
                    run = false;
                }
                else
                {
                    Console.WriteLine("Invalid! Please try again.\n");
                }
            }
        }

        static void ShopMenu()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("*** Shop Menu ***");
                Console.WriteLine("1. Add to Cart");
                Console.WriteLine("2. Remove from Cart");
                Console.WriteLine("3. Checkout");
                Console.WriteLine("4. Exit\n");
                var x = Console.ReadLine() ?? string.Empty;

                if (x.Equals("1", StringComparison.InvariantCultureIgnoreCase))
                {
                    AddToCart();
                }
                else if (x.Equals("2", StringComparison.InvariantCultureIgnoreCase))
                {
                    RemoveFromCart();
                }
                else if (x.Equals("3", StringComparison.InvariantCultureIgnoreCase))
                {
                    Checkout();
                }
                else if (x.Equals("4", StringComparison.InvariantCultureIgnoreCase))
                {
                    run = false;
                }
                else
                {
                    Console.WriteLine("Invalid! Please try again.\n");
                }
            }
        }

        static void AddInventoryItem()
        {
            Console.WriteLine("Enter name of item: ");
            var name = Console.ReadLine();

            Console.WriteLine("Enter description of item: ");
            var description = Console.ReadLine();

            Console.WriteLine("Enter price of item: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price. Please try again.\n");
                return;
            }

            Console.WriteLine("Enter item ID:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please try again.\n");
                return;
            }

            Console.WriteLine("Enter quantity of item: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Invalid quantity. Please try again.\n");
                return;
            }

            Product newProduct = new Product(name, description, price, id, quantity);
            inventoryService.AddOrUpdate(newProduct);

            Console.WriteLine("Product added successfully!\n");
        }

        static void ReadInventoryItems()
        {
            var products = inventoryService.Products;

            if (products.Any())
            {
                Console.WriteLine("Inventory: ");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id}: {product.Name} - {product.Description}, Price: {product.Price:C}, Quantity: {product.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("Inventory is empty.\n");
            }
        }

        static void UpdateInventoryItem()
        {
            Console.WriteLine("Enter product ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please try again.\n");
                return;
            }

            var product = inventoryService.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Console.WriteLine("Product not found.\n");
                return;
            }

            Console.WriteLine("Enter new name of item: ");
            var name = Console.ReadLine();
            product.Name = name;

            Console.WriteLine("Enter new description of item: ");
            var description = Console.ReadLine();
            product.Description = description;

            Console.WriteLine("Enter new price of item: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price. Please try again.\n");
                return;
            }
            product.Price = price;

            Console.WriteLine("Enter new quantity of item: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Invalid quantity. Please try again.\n");
                return;
            }
            product.Quantity = quantity;

            inventoryService.AddOrUpdate(product);
            Console.WriteLine("Product updated successfully!\n");
        }

        static void DeleteInventoryItem()
        {
            Console.WriteLine("Enter product ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please try again.\n");
                return;
            }

            var product = inventoryService.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Console.WriteLine("Product not found.\n");
                return;
            }

            inventoryService.Delete(id);
            Console.WriteLine("Product deleted successfully!\n");
        }

        static void AddToCart()
        {
            Console.WriteLine("Enter the ID of the product you want to add to your cart: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid ID. Please try again.\n");
                return;
            }

            var product = inventoryService.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                Console.WriteLine("Product not found in inventory.\n");
                return;
            }

            Console.WriteLine($"Enter the quantity of '{product.Name}' to add to your cart: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please try again.\n");
                return;
            }

            shoppingCartService.AddToCart(product, quantity);

            Console.WriteLine($"{quantity} {product.Name} added to your cart.\n");
        }

        static void RemoveFromCart()
        {
            Console.WriteLine("Enter product ID to remove from cart: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please try again.\n");
                return;
            }

            var cartItem = shoppingCartService.CartItems.FirstOrDefault(ci => ci.Product.Id == id);
            if (cartItem == null)
            {
                Console.WriteLine("Product not found in cart.\n");
                return;
            }

            Console.WriteLine($"Enter quantity to remove (in cart: {cartItem.Quantity}): ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0 || quantity > cartItem.Quantity)
            {
                Console.WriteLine("Invalid quantity. Please try again.\n");
                return;
            }

            shoppingCartService.RemoveFromCart(cartItem.Product, quantity);
            Console.WriteLine($"Removed {quantity} {cartItem.Product.Name}(s) from cart successfully!\n");
        }

        static void Checkout()
        {
            var receipt = shoppingCartService.Checkout();
            Console.WriteLine(receipt);
        }
    }
}
