using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_commerce.Models
{
	public class Cart
	{
		public int Id { get; set; }
		[DisplayName("Quantity: ")]
		public int Quantity { get; set; }
        public int ItemId { get; set; }
        public Item item { get; set; }
    }
}
