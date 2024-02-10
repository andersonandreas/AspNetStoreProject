using AspNetStoreProject.Models;

namespace AspNetStoreProject.Infrastructure.Models
{
	public interface IStoreRepository
	{

		IQueryable<Product> Products { get; }




	}
}
