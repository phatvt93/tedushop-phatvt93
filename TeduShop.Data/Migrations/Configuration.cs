using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            if (context.ProductCategories.Count() == 0)
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
    }
}