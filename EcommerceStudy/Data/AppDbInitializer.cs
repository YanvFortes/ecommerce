using EcommerceStudy.Data;
using EcommerceStudy.Data.Enums;
using EcommerceStudy.Models.Orders;
using EcommerceStudy.Models.Products;

namespace YourNamespace.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Products
                if (!context.Products.Any())
                {
                    context.IPhones.AddRange(new List<IPhone>()
                    {
                        new IPhone
                        {
                            Name = "iPhone 13 Pro",
                            Price = 999.99M,
                            Description = "Latest iPhone with A15 Bionic chip",
                            Stock = 50,
                            Photo = null, // Add a photo in byte array format if available
                            StorageGB = 128,
                            RamGB = 6,
                            Color = "Silver",
                            Model = IPhoneModel.IPhone13Pro
                        },
                        new IPhone
                        {
                            Name = "iPhone 12",
                            Price = 799.99M,
                            Description = "Previous generation iPhone",
                            Stock = 30,
                            Photo = null,
                            StorageGB = 64,
                            RamGB = 4,
                            Color = "Blue",
                            Model = IPhoneModel.IPhone12
                        }
                    });

                    context.AirPods.AddRange(new List<AirPods>()
                    {
                        new AirPods
                        {
                            Name = "AirPods Pro",
                            Price = 249.99M,
                            Description = "Noise-cancelling AirPods",
                            Stock = 100,
                            Photo = null,
                            Model = AirPodsModel.AirPodsPro,
                        },
                        new AirPods
                        {
                            Name = "AirPods 3",
                            Price = 179.99M,
                            Description = "Third generation AirPods",
                            Stock = 80,
                            Photo = null,
                            Model = AirPodsModel.AirPods3,
                        }
                    });

                    context.Cases.AddRange(new List<Case>()
                    {
                        new Case
                        {
                            Name = "iPhone 13 Pro Case",
                            Price = 39.99M,
                            Description = "Silicone case for iPhone 13 Pro",
                            Stock = 150,
                            Photo = null,
                            Color = "Black",
                            Material = "Silicone",
                            Model = "iPhone 13 Pro"
                        },
                        new Case
                        {
                            Name = "iPhone 12 Case",
                            Price = 29.99M,
                            Description = "Leather case for iPhone 12",
                            Stock = 120,
                            Photo = null,
                            Color = "Brown",
                            Material = "Leather",
                            Model = "iPhone 12"
                        }
                    });

                    context.Chargers.AddRange(new List<Charger>()
                    {
                        new Charger
                        {
                            Name = "20W USB-C Power Adapter",
                            Price = 19.99M,
                            Description = "Fast charging adapter",
                            Stock = 200,
                            Photo = null,
                            PowerWatt = 20,
                            Type = "USB-C"
                        },
                        new Charger
                        {
                            Name = "MagSafe Charger",
                            Price = 39.99M,
                            Description = "Wireless charging for iPhone",
                            Stock = 180,
                            Photo = null,
                            PowerWatt = 15,
                            Type = "MagSafe"
                        }
                    });

                    context.AppleWatches.AddRange(new List<AppleWatch>()
                    {
                        new AppleWatch
                        {
                            Name = "Apple Watch Series 7",
                            Price = 399.99M,
                            Description = "Latest Apple Watch with larger display",
                            Stock = 60,
                            Photo = null,
                            StorageGB = 32,
                            Color = "Red",
                            Model = AppleWatchModel.Series7
                        },
                        new AppleWatch
                        {
                            Name = "Apple Watch SE",
                            Price = 279.99M,
                            Description = "Affordable Apple Watch",
                            Stock = 100,
                            Photo = null,
                            StorageGB = 16,
                            Color = "Blue",
                            Model = AppleWatchModel.SE
                        }
                    });

                    context.SaveChanges();
                }

                // Orders
                if (!context.Orders.Any())
                {
                    var order = new Order
                    {
                        OrderDate = DateTime.Now,
                        UserId = "user1"
                    };
                    context.Orders.Add(order);
                    context.SaveChanges();

                    // OrderItems
                    if (!context.OrderItems.Any())
                    {
                        context.OrderItems.AddRange(new List<OrderItem>()
                        {
                            new OrderItem
                            {
                                OrderId = order.Id,
                                ProductId = context.IPhones.First().Id,
                                Quantity = 1
                            },
                            new OrderItem
                            {
                                OrderId = order.Id,
                                ProductId = context.AirPods.First().Id,
                                Quantity = 2
                            }
                        });
                        context.SaveChanges();
                    }
                }

                // ShoppingCartItems
                if (!context.ShoppingCartItems.Any())
                {
                    context.ShoppingCartItems.AddRange(new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem
                        {
                            ShoppingCartId = "cart1",
                            ProductId = context.Cases.First().Id,
                            Quantity = 3
                        },
                        new ShoppingCartItem
                        {
                            ShoppingCartId = "cart2",
                            ProductId = context.Chargers.First().Id,
                            Quantity = 1
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
