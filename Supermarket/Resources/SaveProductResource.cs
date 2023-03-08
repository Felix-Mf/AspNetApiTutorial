using System.ComponentModel.DataAnnotations;

namespace Supermarket.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; }

        [Required]
        [Range(0, 100)]
        public int QuantityInPackage { get; set; }

        [Required]
        [Range(1, 5)]
        public string UnitOfMeasurement { get; set; } // AutoMapper is going to cast it to the respective enum value

        [Required]
        public int CategoryId { get; set; }
    }
}