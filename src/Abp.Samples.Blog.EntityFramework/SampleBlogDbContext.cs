using System.Data.Common;
using System.Data.Entity;
using Abp.Domain.Repositories;
using Abp.Samples.Blog.Auth;
using Abp.Samples.Blog.Categories;
using Abp.Samples.Blog.Comments;
using Abp.Samples.Blog.Domain.Repositories;
using Abp.Samples.Blog.EntityFramework.Repositories;
using Abp.Samples.Blog.Posts;
using Abp.Zero.EntityFramework;

namespace Abp.Samples.Blog.EntityFramework
{
    [AutoRepositoryTypes(
        typeof(ISampleBlogRepository<>),
        typeof(ISampleBlogRepository<,>),
        typeof(SampleBlogRepositoryBase<>),
        typeof(SampleBlogRepositoryBase<,>)
        )]
    public class SampleBlogDbContext : AbpZeroDbContext<BlogTenant, BlogRole, BlogUser>
    {
        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SampleBlogDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in AbpProjectNameDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of AbpProjectNameDbContext since ABP automatically handles it.
         */
        public SampleBlogDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SampleBlogDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}