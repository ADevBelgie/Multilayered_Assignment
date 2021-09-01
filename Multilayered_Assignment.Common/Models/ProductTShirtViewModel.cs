using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Multilayered_Assignment.Models
{
    public class ProductTShirtViewModel
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Naam")]
        public string Name { get; set; }
        [DisplayName("Prijs")]
        public double Price { get; set; }
        public string Picture { get; set; }
    }
}
