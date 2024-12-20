using System.Text.Json;

namespace JsonTask
{
    public class ProductService
    {
        /*
        void Create(Product product) - example.txt' e product'i yazdirir. (Json formatda)
        Product Get(int id) - verilmis id'li Product'i qaytarir.
        List<Product> Getall() - butun Product'lari qaytarir
        Void Delete(int id) - verilmis id`li Product`i text'den silir
        */
        private string filePath ="C:\\Users\\nonam\\OneDrive\\Masaüstü\\Folder\\example.txt";

        public void Create(Product product)
        {
            List<Product> products = GetAll();
            if (products.Count > 0)
            {
                product.Id = products.Max(p => p.Id) + 1;
            }
            else
            {
                product.Id = 1;
            }
            products.Add(product);
            SaveAll(products);
        }
        private void SaveAll(List<Product> products)
        {
            var productJson = JsonSerializer.Serialize(products);
            File.WriteAllText(filePath, productJson);
        }
        public Product Get(int id)
        {
            List<Product> products = GetAll();
            return products.Find(i => i.Id == id);
        }
        public List<Product> GetAll()
        {
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                return new List<Product>();
            }

            var productJson = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(productJson))
            {
                return new List<Product>();
            }

            return JsonSerializer.Deserialize<List<Product>>(productJson) ?? new List<Product>();
        }
        public void Delete(int id)
        {

            List<Product> products = GetAll();
            var productToDelete = products.Find(i => i.Id == id);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                SaveAll(products);
                Console.WriteLine($"Product with ID {id} deleted.");
            }
            else
            {
                Console.WriteLine($"Error: Product with ID {id} not found.");
            }
        }
    }
}
