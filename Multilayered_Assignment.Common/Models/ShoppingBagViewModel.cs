using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Multilayered_Assignment.Models
{
    public class ShoppingBagViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoppingBagId { get; set; }//PK
        public int LoginId { get; set; }//FK
        public LoginViewModel LoginViewModel { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<ShoppingItemViewModel> Items { get; set; } = new List<ShoppingItemViewModel>();
    }
}
