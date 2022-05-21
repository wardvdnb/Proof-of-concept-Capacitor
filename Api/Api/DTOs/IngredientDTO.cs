using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class IngredientDTO
    {
        [Required]
        public string Name { get; set; }

        public double? Amount { get; set; }

        public string Unit { get; set; }
    }
}
