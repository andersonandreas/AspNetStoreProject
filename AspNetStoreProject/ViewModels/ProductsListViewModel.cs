﻿using AspNetStoreProject.Models;

namespace AspNetStoreProject.ViewModels
{
	public class ProductsListViewModel
	{
		public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

		public PagingInfo PagingInfo { get; set; } = new();

	}
}
