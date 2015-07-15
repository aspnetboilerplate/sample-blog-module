using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace Abp.Samples.Blog.Domain.Repositories
{
    public interface ISampleBlogRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {

    }

    public interface ISampleBlogRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {

    }
}