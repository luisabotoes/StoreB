namespace StoreB.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Entities;
    using StoreB.Web.Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");

            var user = await this.userHelper.GetUserByEmailAsync("luisa.martins.oficial@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Luísa",
                    LastName = "Martins",
                    Email = "luisa.martins.oficial@gmail.com",
                    UserName = "luisa.martins.oficial@gmail.com",
                    PhoneNumber = "929229292"
                };

                var result = await this.userHelper.AddUserAsync(user, "122256");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder.");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("Equipamento oficial SLB", user);
                this.AddProduct("Chuteiras oficiais", user);
                this.AddProduct("Águia de peluche", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(200),
                IsAvailable = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}

