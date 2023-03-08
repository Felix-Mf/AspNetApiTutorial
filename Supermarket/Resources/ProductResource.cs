namespace Supermarket.Resources
{
    public class ProductResource
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public CategoryResource Category { get; set; }
    }
}