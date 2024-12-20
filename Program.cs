namespace JsonTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\nonam\\OneDrive\\Masaüstü\\Folder";
            string file = path + "\\example.txt";

            try
            {

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                if (!File.Exists(file))
                {
                    using (File.Create(file)) 
                    {
                    
                    }
                }

                ProductService productService = new ProductService();



                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("1. All Products - Display all products");
                    Console.WriteLine("2. Get Product - Retrieve a product by ID");
                    Console.WriteLine("3. Create Product - Create a new product");
                    Console.WriteLine("4. Delete Product - Delete a product by ID");
                    Console.WriteLine("5. Exit - Exit the program");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    try
                    {
                        switch (choice)
                        {
                            case "1":
                                var products = productService.GetAll();
                                Console.WriteLine("All Products:");
                                if (products.Count > 0)
                                {
                                    foreach (var product in products)
                                    {
                                        Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Cost Price: {product.CostPrice}, Sale Price: {product.SalePrice}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No products found.");
                                }
                                break;

                            case "2":
                                Console.Write("Enter Product ID: ");
                                if (int.TryParse(Console.ReadLine(), out int id))
                                {
                                    var product = productService.Get(id);
                                    if (product != null)
                                    {
                                        Console.WriteLine($"Product found: Id: {product.Id}, Name: {product.Name}, Cost Price: {product.CostPrice}, Sale Price: {product.SalePrice}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Error: Product with ID {id} not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID format.");
                                }
                                break;

                            case "3":
                                Console.Write("Enter Product Name: ");
                                string name = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(name))
                                {
                                    Console.Write("Enter Product Cost Price: ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal costPrice))
                                    {
                                        Console.Write("Enter Product Sale Price: ");
                                        if (decimal.TryParse(Console.ReadLine(), out decimal salePrice))
                                        {
                                            Product newProduct = new Product { Name = name, CostPrice = costPrice, SalePrice = salePrice };
                                            productService.Create(newProduct);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error: Invalid sale price format.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error: Invalid cost price format.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error: Product Name cannot be empty or whitespace. Please enter a valid name.");
                                }
                                break;

                            case "4":
                                Console.Write("Enter Product ID to delete: ");
                                if (int.TryParse(Console.ReadLine(), out int deleteId))
                                {
                                    productService.Delete(deleteId);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID format.");
                                }
                                break;

                            case "5":
                                exit = true;
                                break;

                            default:
                                Console.WriteLine("Invalid choice, please try again.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting up the file or directory: {ex.Message}");
            }
        }
    }
}


