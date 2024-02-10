using AspNetStoreProject.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetStoreProject.Controllers
{
	public class HomeController : Controller
	{

		private IStoreRepository _repository;

		public HomeController(IStoreRepository repo)
		{
			_repository = repo;
		}


		public IActionResult Index()
		{
			return View(_repository.Products);
		}




	}
}
