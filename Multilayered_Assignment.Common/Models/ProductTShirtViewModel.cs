using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Multilayered_Assignment.Models
{
    public class ProductTShirtViewModel :IValidatableObject
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("Naam")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Prijs")]
        public double Price { get; set; }
        [Required]
        public string Picture { get; set; }
        [StringLength(8, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 8)]
        public string TshirtRegistrationNumer { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // First 3 characters of TshirtRegistrationNumer have to be "ABC"
            if (TshirtRegistrationNumer != null)
            {
                string first3Char = TshirtRegistrationNumer.Substring(0,3);
                if (first3Char != "ABC")
                {
                    yield return new ValidationResult(
                "First 3 characters of TshirtRegistrationNumer have to be \"ABC\"",
                new[] { nameof(TshirtRegistrationNumer) });
                }
            }
        }
    }
}
