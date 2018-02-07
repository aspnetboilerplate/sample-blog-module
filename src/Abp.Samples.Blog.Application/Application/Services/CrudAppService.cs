using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Samples.Blog.Application.Dtos;

namespace Abp.Samples.Blog.Application.Services
{
    //TODO: Auto mappings..?
    //TODO: Select request should be sortable?

    public abstract class CrudAppService<TRepository, TEntity, TEntityDto, TPrimaryKey, TSelectRequestInput, TCreateInput, TUpdateInput>
        : AbpServiceBase, ICrudAppService<TEntityDto, TPrimaryKey, TSelectRequestInput, TCreateInput, TUpdateInput>
        where TSelectRequestInput : IPagedResultRequest
        where TRepository : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TUpdateInput : EntityDto<TPrimaryKey>
    {
        protected readonly TRepository Repository;

        static CrudAppService()
        {
        }

        protected CrudAppService(TRepository repository)
        {
            Repository = repository;
        }

        public TEntityDto Get(EntityDto<TPrimaryKey> input)
        {
            return Repository.Get(input.Id).MapTo<TEntityDto>();
        }

        public virtual PagedResultDto<TEntityDto> GetAll(TSelectRequestInput input)
        {
            var query = CreateQueryable(input);

            return new PagedResultDto<TEntityDto>(
                query.Count(),
                CreateQueryable(input).OrderByDescending(e => e.Id).PageBy(input).MapTo<List<TEntityDto>>()
                );
        }

        public virtual TPrimaryKey Create(TCreateInput input)
        {
            return Repository.InsertOrUpdateAndGetId(input.MapTo<TEntity>());
        }

        public virtual void Update(TUpdateInput input)
        {
            var entity = Repository.Get(input.Id);
            input.MapTo(entity);
        }

        public virtual void Delete(EntityDto<TPrimaryKey> input)
        {
            Repository.Delete(input.Id);
        }

        protected virtual IQueryable<TEntity> CreateQueryable(TSelectRequestInput input)
        {
            return Repository.GetAll();
        }
    }

    public abstract class CrudAppService<TRepository, TEntity, TEntityDto, TPrimaryKey, TSelectRequestInput>
        : CrudAppService<TRepository, TEntity, TEntityDto, TPrimaryKey, TSelectRequestInput, TEntityDto, TEntityDto>
        where TSelectRequestInput : IPagedResultRequest
        where TRepository : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : EntityDto<TPrimaryKey>
    {
        protected CrudAppService(TRepository repository)
            : base(repository)
        {
        }
    }

    public abstract class CrudAppService<TRepository, TEntity, TEntityDto, TPrimaryKey>
        : CrudAppService<TRepository, TEntity, TEntityDto, TPrimaryKey, DefaultPagedResultRequest>
        where TRepository : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : EntityDto<TPrimaryKey>
    {
        protected CrudAppService(TRepository repository)
            : base(repository)
        {
        }
    }

    public abstract class CrudAppService<TEntity, TEntityDto, TPrimaryKey>
        : CrudAppService<IRepository<TEntity, TPrimaryKey>, TEntity, TEntityDto, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : EntityDto<TPrimaryKey>
    {
        protected CrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public abstract class CrudAppService<TEntity, TEntityDto>
        : CrudAppService<TEntity, TEntityDto, int>
        where TEntity : class, IEntity<int>
        where TEntityDto : EntityDto<int>
    {
        protected CrudAppService(IRepository<TEntity, int> repository)
            : base(repository)
        {
        }
    }
}