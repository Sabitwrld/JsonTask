namespace JsonTask
{
    public class Product
    {
        public static int _id = 1;
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal CostPrice { get; set; }
        private decimal _salePrice;
        public decimal SalePrice
        {
            get => _salePrice;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Sale Price cannot be negative.");
                }

                if (value <= CostPrice)
                {
                    throw new Exception("Sale Price must be greater than Cost Price.");
                }

                _salePrice = value;
            }
        }
        public Product(string name, decimal costPrice, decimal salePrice)
        {
            if (costPrice < 0 || salePrice < 0)
            {
                throw new Exception("Cost Price and Sale Price must be non-negative.");
            }
            Id = _id++;
            Name = name;
            CostPrice = costPrice;
            SalePrice = salePrice;
        }
        public Product()
        {
        }
    }
}
