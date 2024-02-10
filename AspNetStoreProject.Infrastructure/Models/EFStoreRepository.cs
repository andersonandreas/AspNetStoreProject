using AspNetStoreProject.Models;

namespace AspNetStoreProject.Infrastructure.Models
{
	public class EFStoreRepository : IStoreRepository
	{

		private StoreDbContext _context;

		public EFStoreRepository(StoreDbContext context)
		{
			_context = context;
		}


		public IQueryable<Product> Products => _context.Products;



	}
}
