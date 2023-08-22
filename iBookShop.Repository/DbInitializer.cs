using iBookShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iBookShop.Repository
{
    public class DbInitializer : IDbInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _UserManager = userManager;
            _context = context;
        }

        public string UserName { get; private set; }

        private string Email;

        public string Name { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    
                        _context.Database.Migrate();
                    
                }
            }
            catch (Exception)
            {
                throw;
            }

                if (_context.Roles.Any(x => x.Name == "Admin")) return;
                _roleManager.CreateAsync(new IdentityRole("Manager")).
                    GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Admin")).
                    GetAwaiter().GetResult();

                _roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();

                var user = new ApplicationUser();
                {
                    UserName = "admin@gmail.com",
                        Email = "admin@gmail.com",
                        Name = "Admin",
                        City = "Luton",
                        Address = "Westbourne",
                        PostalCode = "LU4 8JD"
                };

                _UserManager.CreateAsync(user, "Admin@123").GetAwaiter().GetResult();

                _UserManager.AddToRoleAsync(user, "Admin");

            }
}
    }

