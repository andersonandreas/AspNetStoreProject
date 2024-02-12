namespace AspNetStoreProject.ViewModels
{
	public class PagingInfo
	{
		public int TotalItems { get; set; }
		public int ItemsPerPage { get; set; }
		public int CurrentPage { get; set; }

		public int TotalPages()
		{
			int total = (int)Math.Ceiling((decimal)TotalItems) / ItemsPerPage;

			return total;
		}


	}
}
