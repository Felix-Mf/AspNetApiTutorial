using System.ComponentModel.DataAnnotations;

namespace Supermarket.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string CategoryName { get; set; }
    }
}