using E_commerce.Data;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
	public class ItemsController : Controller
	{
		ApplicationDbContext _context;
		IWebHostEnvironment _webHostEnvironment;

		public ItemsController(ApplicationDbContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_webHostEnvironment = environment;
		}

		[HttpGet]
		public IActionResult GetIndexView()
		{
			return View("Index", _context.Items.ToList());
		}

		[HttpGet]
		public IActionResult GetCreateView()
		{
			return View("Create");
		}

		[HttpPost]
		public IActionResult AddNewItem(Item item, IFormFile? itemImage)
		{
			if(itemImage != null)
			{
				Guid guid = Guid.NewGuid();
				string imageName = guid + Path.GetExtension(itemImage.FileName); ;
				string imgUrl = "\\images\\" + imageName;
				item.ImageUrl = imgUrl;
				string imgPath = _webHostEnvironment.WebRootPath + imgUrl;

				FileStream imgStream = new(imgPath, FileMode.Create);
				itemImage.CopyTo(imgStream);
				imgStream.Dispose();
			}
			else
			{
				item.ImageUrl = "\\images\\No_Image.png";
			}
			
			if(ModelState.IsValid)
			{
				_context.Items.Add(item);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView", "Dashboard");
			}
			else
			{
				return View("Create");
			}
		}

		[HttpGet]
		public IActionResult GetEditView(int id)
		{
			Item item = _context.Items.FirstOrDefault(item => item.Id == id);
			if(item != null)
			{
				return View("Edit", item);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPost]
		public IActionResult EditItem(Item item, IFormFile? itemImage)
		{
			if(itemImage != null)
			{
				if (item.ImageUrl != "\\images\\No_Image.png")
				{
					if(System.IO.File.Exists(_webHostEnvironment.WebRootPath + item.ImageUrl)) 
					{
						System.IO.File.Delete(_webHostEnvironment.WebRootPath + item.ImageUrl);
					}
				}
				Guid guid = Guid.NewGuid();
				string imgUrl = "\\images\\" + guid + Path.GetExtension(itemImage.FileName);
				item.ImageUrl = imgUrl;
				string imgPath = _webHostEnvironment.WebRootPath + imgUrl;

				FileStream fileStream = new(imgPath, FileMode.Create);
				itemImage.CopyTo(fileStream);
				fileStream.Dispose();
			}
			if(ModelState.IsValid)
			{
				_context.Items.Update(item);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView", "Dashboard");
			}
			else
			{
				return View("Edit");
			}
		}

		[HttpGet]
		public IActionResult GetDeleteView(int id)
		{
			Item item = _context.Items.FirstOrDefault(i => i.Id == id);
			if(item != null)
			{
				return View("Delete", item);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPost]
		public IActionResult DeleteItem(int id)
		{
			Item item = _context.Items.FirstOrDefault(i => i.Id == id);
			if(item != null)
			{
				if(item.ImageUrl != "\\images\\No_Image.png")
				{
					if(System.IO.File.Exists(_webHostEnvironment.WebRootPath + item.ImageUrl))
					{
						System.IO.File.Delete(_webHostEnvironment.WebRootPath + item.ImageUrl);
					}
				}
				_context.Items.Remove(item);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView", "Dashboard");
			}
			else
			{
				return NotFound();
			}
		}
	}
}
