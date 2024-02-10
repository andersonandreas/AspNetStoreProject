using AspNetStoreProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetStoreProject.Infrastructure.Models
{
	public class SeedData
	{

		public static void MakeSureDbIsPopulated(IApplicationBuilder app)
		{
			StoreDbContext context = app.ApplicationServices
				.CreateScope().ServiceProvider
				.GetRequiredService<StoreDbContext>();

			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}

			if (!context.Products.Any())
			{
				context.Products.AddRange(

					new Product
					{
						Name = "Lenovo",
						Description = "15.6 inch, Intel Core i7, 16GB RAM, 512GB SSD",
						Category = "Laptop",
						Price = 999.99m
					},
					new Product
					{
						Name = "Dell",
						Description = "27 inch, 4K Resolution, IPS Panel",
						Category = "Monitor",
						Price = 349.99m
					},
					new Product
					{
						Name = "Custom Keyboard",
						Description = "Mechanical, RGB Backlit",
						Category = "Accessories",
						Price = 89.99m
					},
					new Product
					{
						Name = "IntelMouse",
						Description = "Wireless, Ergonomic Design",
						Category = "Accessories",
						Price = 49.99m
					},
					new Product
					{
						Name = "Desktop PC",
						Description = "High-Performance, Intel Core i9, 32GB RAM, RTX Graphics",
						Category = "Computer",
						Price = 1999.99m
					},
					new Product
					{
						Name = "Webcam",
						Description = "1080p HD, Built-in Microphone",
						Category = "Accessories",
						Price = 39.99m
					},
					new Product
					{
						Name = "Headset",
						Description = "Wireless, Noise Cancelling",
						Category = "Sound",
						Price = 119.99m
					},
					new Product
					{
						Name = "Smartphone",
						Description = "Latest Model, 5G, High-Resolution Camera",
						Category = "Phone",
						Price = 799.99m
					},
					new Product
					{
						Name = "Smartwatch",
						Description = "Fitness Tracker, Heart Rate Monitor, GPS",
						Category = "Watch",
						Price = 249.99m
					}

				);

				context.SaveChanges();
			}


		}


	}
}



