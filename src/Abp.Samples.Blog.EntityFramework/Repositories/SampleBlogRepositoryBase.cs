using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Abp.Samples.Blog.Domain.Repositories;

namespace Abp.Samples.Blog.EntityFramework.Repositories
{
    public class SampleBlogRepositoryBase<TEntity> : SampleBlogRepositoryBase<TEntity, int>, ISampleBlogRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public SampleBlogRepositoryBase(IDbContextProvider<SampleBlogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }

    public class SampleBlogRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SampleBlogDbContext, TEntity, TPrimaryKey>, ISampleBlogRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public SampleBlogRepositoryBase(IDbContextProvider<SampleBlogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}