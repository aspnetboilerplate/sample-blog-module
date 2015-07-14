using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.MultiTenancy;
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
            var admin = _context.Users.Single(u => u.TenantId == 1 && u.UserName == BlogUser.AdminUserName);

            //TODO: ...

            //_context.Posts.Add(new Post
            //                   {
                                   
            //                   });
        }
    }
}
