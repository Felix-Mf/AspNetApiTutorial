namespace Supermarket.Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}