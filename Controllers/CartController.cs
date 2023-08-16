using E_commerce.Data;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Controllers
{
	public class CartController : Controller
	{
		ApplicationDbContext _context;
		
		public CartController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult GetIndexView()
		{
			List<Cart> carts = _context.CartItems.Include(i => i.item).ToList();
			return View("Index", carts);
		}

		[HttpPost]
		public IActionResult AddToCart(Item item)
		{
			Cart cartItem = _context.CartItems.FirstOrDefault(x => x.ItemId == item.Id);
			if(cartItem == null)
			{
				cartItem = new()
				{
					Quantity = 1,
					ItemId = item.Id,
				};
				_context.CartItems.Add(cartItem);
			}
			else
			{
				++cartItem.Quantity;
			}
			_context.SaveChanges();
			return RedirectToAction("GetIndexView");
		}

		[HttpPost]
		public IActionResult DeleteCartItem(int id)
		{
			Cart cartItem = _context.CartItems.FirstOrDefault(x => x.Id == id);
			if(cartItem == null)
			{
				return NotFound();
			}
			else
			{
				_context.CartItems.Remove(cartItem);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
		}

		[HttpGet]
		public IActionResult IncreaseQuantity(int id)
		{
			Cart cartItem = _context.CartItems.FirstOrDefault(x => x.Id == id);
			cartItem.Quantity++;
            _context.SaveChanges();
			return RedirectToAction("GetIndexView");
		}

		[HttpGet]
		public IActionResult DecreaseQuantity(int id)
		{
			Cart cartItem = _context.CartItems.FirstOrDefault(x => x.Id == id);
			cartItem.Quantity--;
			_context.SaveChanges();
			return RedirectToAction("GetIndexView");
		}
	}


}
