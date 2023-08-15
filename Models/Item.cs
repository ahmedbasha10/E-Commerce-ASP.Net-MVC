using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
	public class Item
	{
        public int Id { get; set; }
        [DisplayName("Item Name: ")]
        [Required(ErrorMessage = "You have to enter Item Name.")]
        [MinLength(2, ErrorMessage = "Item Name mustn't be less than 2 charactes.")]
        [MaxLength(30, ErrorMessage = "Item Name mustn't exceed 30 characters.")]
		public string Name { get; set;}
        [DisplayName("Item Price: ")]
        [Required(ErrorMessage = "You have to enter Item Price.")]
        [Range(30, 1000, ErrorMessage = "Item price should be between 30$ and 1000$")]
        public decimal Price { get; set; }
        [ValidateNever]
        [DisplayName("Item Image: ")]
        public string ImageUrl { get; set; }

    }
}
