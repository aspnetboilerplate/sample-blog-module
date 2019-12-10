using System.Linq;
using Abp.Authorization.Users;
using Abp.Samples.Blog.Auth;
using Abp.Samples.Blog.Categories;
using Abp.Samples.Blog.Posts;

namespace Abp.Samples.Blog.EntityFramework.Migrations.SeedData
{
    public class BlogTestDataBuilder
    {
        private readonly SampleBlogDbContext _context;

        public BlogTestDataBuilder(SampleBlogDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateUserAndRoles();
            CreateCategories();
            CreatePosts();
        }

        private void CreateCategories()
        {
            if (_context.Categories.Any())
            {
                return;
            }

            _context.Categories.Add(new Category { Name = "Programming" });
            _context.Categories.Add(new Category { Name = "Design" });

            _context.SaveChanges();
        }
        private void CreateUserAndRoles()
        {
            //Admin role for tenancy owner

            var adminRoleForTenancyOwner = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == "Admin");
            if (adminRoleForTenancyOwner == null)
            {
                adminRoleForTenancyOwner = _context.Roles.Add(new BlogRole { Name = "Admin", DisplayName = "Admin" });
                _context.SaveChanges();
            }

            //Admin user for tenancy owner

            var adminUserForTenancyOwner = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == "admin");
            if (adminUserForTenancyOwner == null)
            {
                adminUserForTenancyOwner = _context.Users.Add(
                    new BlogUser
                    {
                        TenantId = null,
                        UserName = "admin",
                        Name = "System",
                        Surname = "Administrator",
                        NormalizedUserName = "ADMIN",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        NormalizedEmailAddress = "ADMIN@ASPNETBOILERPLATE.COM",
                        IsEmailConfirmed = true,
                        Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" //123qwe
                    });

                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(null, adminUserForTenancyOwner.Id, adminRoleForTenancyOwner.Id));

                _context.SaveChanges();
            }

            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == "Default");
            if (defaultTenant == null)
            {
                defaultTenant = _context.Tenants.Add(new BlogTenant { TenancyName = "Default", Name = "Default" });
                _context.SaveChanges();
            }

            //Admin role for 'Default' tenant

            var adminRoleForDefaultTenant = _context.Roles.FirstOrDefault(r => r.TenantId == defaultTenant.Id && r.Name == "Admin");
            if (adminRoleForDefaultTenant == null)
            {
                adminRoleForDefaultTenant = _context.Roles.Add(new BlogRole { TenantId = defaultTenant.Id, Name = "Admin", DisplayName = "Admin" });
                _context.SaveChanges();
            }

            //Admin for 'Default' tenant

            var adminUserForDefaultTenant = _context.Users.FirstOrDefault(u => u.TenantId == defaultTenant.Id && u.UserName == "admin");
            if (adminUserForDefaultTenant == null)
            {
                adminUserForDefaultTenant = _context.Users.Add(
                    new BlogUser
                    {
                        TenantId = defaultTenant.Id,
                        UserName = "admin",
                        Name = "System",
                        Surname = "Administrator",
                        NormalizedUserName = "ADMIN",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        NormalizedEmailAddress = "ADMIN@ASPNETBOILERPLATE.COM",
                        IsEmailConfirmed = true,
                        Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" //123qwe
                    });
                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(defaultTenant.Id, adminUserForDefaultTenant.Id, adminRoleForDefaultTenant.Id));
                _context.SaveChanges();
            }
        }

        private void CreatePosts()
        {
            if (_context.Posts.Any())
            {
                return;
            }

            const int defaultTenantId = 1;

            var adminUser = _context.Users.Single(u => u.TenantId == defaultTenantId && u.UserName == BlogUser.AdminUserName);
            var programmingCategory = _context.Categories.FirstOrDefault(c => c.Name == "Programming");

            _context.Posts.Add(
                new Post
                {
                    CategoryId = programmingCategory.Id,
                    Title = "Introduction to ASP.NET Boilerplate",
                    Content = "ASP.NET Boilerplate is a starting point for new modern web applications using best practices and most popular tools. It's aimed to be a solid model, a general-purpose application framework and a project template.",
                    Status = PostStatus.Published,
                    Tags = "domain driven design",
                    CreatorUserId = adminUser.Id
                });

            _context.Posts.Add(
                new Post
                {
                    CategoryId = programmingCategory.Id,
                    Title = "Unit testing in C# using xUnit, Entity Framework, Effort and ASP.NET Boilerplate.",
                    Content = "Implemented unit and integration tests on ASP.NET Boilerplate framework using xUnit, Entity Framework, Effort and Shouldly. See http://www.codeproject.com/Articles/871786/Unit-testing-in-Csharp-using-xUnit-Entity-Framewor for details...",
                    Status = PostStatus.Published,
                    Tags = "domain driven design",
                    CreatorUserId = adminUser.Id
                });

            _context.SaveChanges();
        }
    }
}
