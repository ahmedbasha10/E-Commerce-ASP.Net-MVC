using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_commerce.Models
{
	public class User
	{
		public int Id { get; set; }
		[DisplayName("Name: ")]
		[Required(ErrorMessage = "You have to enter Name.")]
		[MinLength(3, ErrorMessage = "Name mustn't be less than 2 charactes.")]
		[MaxLength(50, ErrorMessage = "Name mustn't exceed 30 characters.")]
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string ImageUrl { get; set; }

	}
}
