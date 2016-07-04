﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using TeduShop.Model.Models;

namespace TeduShop.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShopDbContext context)
        {
            CreateProductCategorySample(context);
            CreateSlide(context);
            CreateProduct(context);
            CreatePage(context);
            CreateContactDetail(context);
            //  This method will be called after migrating to the latest version.

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "tedu",
            //    Email = "tedu.international@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Technology Education"

            //};

            //manager.Create(user, "123654$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(TeduShopDbContext context)
        {
            if (!context.ProductCategories.Any())
            {
                var listProductCategories = new List<ProductCategory>
                {
                    new ProductCategory
                    {
                        Name = "Điện lạnh",
                        Alias = "dien-lanh",
                        Status = true,
                        CreatedDate = DateTime.Now
                    },
                    new ProductCategory
                    {
                        Name = "Viễn thông",
                        Alias = "vien-thong",
                        Status = true,
                        CreatedDate = DateTime.Now
                    },
                    new ProductCategory
                    {
                        Name = "Đồ gia dụng",
                        Alias = "do-gia-dung",
                        Status = true,
                        CreatedDate = DateTime.Now
                    },
                    new ProductCategory {Name = "Mỹ phẩm", Alias = "my-pham", Status = true, CreatedDate = DateTime.Now}
                };

                context.ProductCategories.AddRange(listProductCategories);
                context.SaveChanges();
            }
        }

        private void CreateSlide(TeduShopDbContext context)
        {
            if (!context.Slides.Any())
            {
                var listSlide = new List<Slide>
                {
                    new Slide
                    {
                        Name = "Slide 1",
                        DisplayOrder = 1,
                        Status = true,
                        Url = "#",
                        Image = "/Assets/client/images/bag.jpg",
                        Content = @"	<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur 
                            adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                        <span class='on-get'>GET NOW</span>"
                    },
                    new Slide
                    {
                        Name = "Slide 2",
                        DisplayOrder = 2,
                        Status = true,
                        Url = "#",
                        Image = "/Assets/client/images/bag1.jpg",
                        Content = @"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=\'on-get\'>GET NOW</span>"
                    }
                };

                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }

        private void CreateProduct(TeduShopDbContext context)
        {
            if (!context.Products.Any())
            {
                List<Product> listProduct = new List<Product>()
                {
                    new Product() { Name = "Sản phẩm 1", Alias = "san-pham-1",
                        Image = "/Assets/client/images/ch.jpg",
                        Price = 2000000, PromotionPrice = 1000000,
                        CreatedDate = DateTime.Now, HomeFlag = true,
                        HotFlag = true, CategoryID = 1, Status = true},
                    new Product() { Name = "Sản phẩm 2", Alias = "san-pham-2",
                        Image = "/Assets/client/images/ba.jpg",
                        Price = 22000000, PromotionPrice = 10000000,
                        CreatedDate = DateTime.Now, HomeFlag = true,
                        HotFlag = true, CategoryID = 2, Status = true},
                    new Product() { Name = "Sản phẩm 3", Alias = "san-pham-3",
                        Image = "/Assets/client/images/bo.jpg",
                        Price = 2600000, PromotionPrice = 1600000,
                        CreatedDate = DateTime.Now, HomeFlag = true,
                        HotFlag = true, CategoryID = 1, Status = true},
                    new Product() { Name = "Sản phẩm 4", Alias = "san-pham-4",
                        Image = "/Assets/client/images/bott.jpg",
                        Price = 9999999, PromotionPrice = 8888888,
                        CreatedDate = DateTime.Now, HomeFlag = true,
                        HotFlag = true, CategoryID = 1, Status = true},
                    new Product() { Name = "Sản phẩm 5", Alias = "san-pham-5",
                        Image = "/Assets/client/images/baa.jpg",
                        Price = 9999999, PromotionPrice = 8888888,
                        CreatedDate = DateTime.Now, HomeFlag = true,
                        HotFlag = true, CategoryID = 1, Status = true},
                    new Product() { Name = "Sản phẩm 6", Alias = "san-pham-6",
                        Image = "/Assets/client/images/bottle.jpg",
                        Price = 9999999, PromotionPrice = 8888888,
                        CreatedDate = DateTime.Now, HomeFlag = true,
                        HotFlag = true, CategoryID = 1, Status = true}
                };

                context.Products.AddRange(listProduct);
                context.SaveChanges();
            }
        }

        private void CreatePage(TeduShopDbContext context)
        {
            if (!context.Pages.Any())
            {
                var page = new Page()
                {
                    Name = "Giới thiệu",
                    Alias = "gioi-thieu",
                    Content = @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium ",
                    Status = true
                };

                context.Pages.Add(page);
                context.SaveChanges();
            }
        }

        private void CreateContactDetail(TeduShopDbContext context)
        {
            if (!context.ContactDetails.Any())
            {
                try
                {
                    var contactDetail = new TeduShop.Model.Models.ContactDetail()
                    {
                        Name = "Shop thời trang TEDU",
                        Address = "Ngõ 77 Xuân La",
                        Email = "tedu@gmail.com",
                        Lat = 21.0633645,
                        Lng = 105.8053274,
                        Phone = "095423233",
                        Website = "http://tedu.com.vn",
                        Other = "",
                        Status = true

                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }
            }
        }
    }
}