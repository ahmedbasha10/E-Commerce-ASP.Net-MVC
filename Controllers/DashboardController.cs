using E_commerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
	public class DashboardController : Controller
	{
		ApplicationDbContext _context;
		public DashboardController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult GetIndexView()
		{
			return View("Index", _context.Items.ToList());
		}
	}
}
