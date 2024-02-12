using AspNetStoreProject.Controllers;
using AspNetStoreProject.Infrastructure.Models;
using AspNetStoreProject.Models;
using AspNetStoreProject.ViewModels;
using Moq;

namespace AspNetStoreProject.Tests
{
	public class HomeControllerTests
	{


		[Fact]
		public void Check_The_Repository_Method_Test()
		{

			// Arrange 
			var mock = new Mock<IStoreRepository>();

			mock.Setup(m => m.Products)
				.Returns((new Product[] {
				new() { Id = 1, Name  = "MacBook Pro M2 Pro"},
				new() { Id = 2, Name  = "MacBook Pro M3 Pro"}
			})
			.AsQueryable());

			var controller = new HomeController(mock.Object);


			// Act

			ProductsListViewModel result = controller.Index()
				?.ViewData.Model as ProductsListViewModel ?? new();


			// Assert 
			var productsArr = result.Products.ToArray();

			Assert.True(productsArr.Length == 2);
			Assert.Equal("MacBook Pro M2 Pro", productsArr[0].Name);
			Assert.Equal("MacBook Pro M3 Pro", productsArr[1].Name);

		}


		[Fact]
		public void PaginationProducts_PageSize_2_Test()
		{
			// Arrange
			var mock = new Mock<IStoreRepository>();
			mock.Setup(m => m.Products)
				.Returns((new Product[] {
				new() { Id = 1, Name = "MacBook Pro M2 Pro" },
				new() { Id = 2, Name = "MacBook Pro M3 Pro" },
				new() { Id = 3, Name = "MacBook Air M2" },
				new() { Id = 4, Name = "MacBook Pro M1" },
				new() { Id = 5, Name = "MacBook Air M1" }
			})
			.AsQueryable());

			var controller = new HomeController(mock.Object);
			controller.PageSize = 2;

			// Act
			ProductsListViewModel result = controller.Index(2)
				?.ViewData.Model as ProductsListViewModel ?? new();


			//Assert
			var productsArr = result.Products.ToArray();

			Assert.True(productsArr.Length == 2);
			Assert.Equal("MacBook Air M2", productsArr[0].Name);
			Assert.Equal("MacBook Pro M1", productsArr[1].Name);

		}


		[Fact]
		public void Sending_The_Right_And_Can_Pagination_ViewModel_With_PageSize_3_Test()
		{

			//Arrange
			var mock = new Mock<IStoreRepository>();
			mock.Setup(m => m.Products)
				.Returns((new Product[] {
				new() { Id = 1, Name = "MacBook Pro M2 Pro" },
				new() { Id = 2, Name = "MacBook Pro M3 Pro" },
				new() { Id = 3, Name = "MacBook Air M2" },
				new() { Id = 4, Name = "MacBook Pro M1" },
				new() { Id = 5, Name = "MacBook Air M1" }
			})
			.AsQueryable());

			var controller = new HomeController(mock.Object) { PageSize = 3 };


			//Act
			ProductsListViewModel result = controller.Index(2)
				?.ViewData.Model as ProductsListViewModel ?? new();


			//Assert
			var pageInfo = result.PagingInfo;

			Assert.Equal(2, pageInfo.CurrentPage);
			Assert.Equal(3, pageInfo.ItemsPerPage);
			Assert.Equal(5, pageInfo.TotalItems);

		}



	}
}
