using System.Linq;
using Abp.Samples.Blog.Auth;
using Abp.Samples.Blog.Categories;
using Abp.Samples.Blog.EntityFramework;
using Abp.Samples.Blog.Posts;

namespace Abp.Samples.Blog.Tests.Data
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
            CreateCategories();
            CreatePosts();
        }

        private void CreateCategories()
        {
            _context.Categories.Add(new Category { Name = "Programming" });
            _context.Categories.Add(new Category { Name = "Design" });
            
            _context.SaveChanges();
        }

        private void CreatePosts()
        {
            const int defaultTenantId = 1;

            var adminUser = _context.Users.Single(u => u.TenantId == defaultTenantId && u.UserName == BlogUser.AdminUserName);
            var programmingCategory = _context.Categories.Single(c => c.Name == "Programming");

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
