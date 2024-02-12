using AspNetStoreProject.Infrastructure.Models;
using AspNetStoreProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetStoreProject.Controllers
{
	public class HomeController : Controller
	{

		private IStoreRepository _repository;
		public int PageSize { get; set; } = 4;

		public HomeController(IStoreRepository repo)
		{
			_repository = repo;
		}


		public ViewResult Index(int pageProduct = 1)
		{

			var ProductListViewModel = new ProductsListViewModel
			{
				Products = _repository.Products
				.OrderBy(p => p.Id)
				.Skip((pageProduct - 1) * PageSize)
				.Take(PageSize),

				PagingInfo = new PagingInfo
				{
					CurrentPage = pageProduct,
					ItemsPerPage = PageSize,
					TotalItems = _repository.Products.Count()
				}
			};

			return View(ProductListViewModel);
		}




	}
}
