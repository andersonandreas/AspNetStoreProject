using AspNetStoreProject.Controllers;
using AspNetStoreProject.Infrastructure.Models;
using AspNetStoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AspNetStoreProject.Tests
{
	public class HomeControllerTests
	{


		[Fact]
		public void Check_The_Repository_Method()
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
			IEnumerable<Product>? result = (controller.Index() as ViewResult)?.ViewData.Model
				as IEnumerable<Product>;


			// Assert 
			var productsArr = result?.ToArray() ?? Array.Empty<Product>();

			Assert.True(productsArr.Length == 2);
			Assert.Equal("MacBook Pro M2 Pro", productsArr[0].Name);
			Assert.Equal("MacBook Pro M3 Pro", productsArr[1].Name);

		}




	}
}
