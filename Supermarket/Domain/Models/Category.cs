using System.Collections.Generic;

namespace Supermarket.Domain.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}