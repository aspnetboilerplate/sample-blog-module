using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Samples.Blog.Application.Dtos;

namespace Abp.Samples.Blog.Application.Services
{
    public interface ICrudAppService<TEntityDto, TPrimaryKey, in TSelectRequestInput, in TCreateInput, in TUpdateInput>
        : IApplicationService
        where TSelectRequestInput : IPagedResultRequest
    {
        TEntityDto Get(EntityDto<TPrimaryKey> input);

        PagedResultDto<TEntityDto> GetAll(TSelectRequestInput input);

        TPrimaryKey Create(TCreateInput input);

        void Update(TUpdateInput input);

        void Delete(EntityDto<TPrimaryKey> input);
    }

    public interface ICrudAppService<TEntityDto, TPrimaryKey, in TSelectRequestInput>
        : ICrudAppService<TEntityDto, TPrimaryKey, TSelectRequestInput, TEntityDto, TEntityDto>
        where TSelectRequestInput : IPagedResultRequest
    {

    }

    public interface ICrudAppService<TEntityDto, TPrimaryKey>
        : ICrudAppService<TEntityDto, TPrimaryKey, DefaultPagedResultRequest>
    {

    }

    public interface ICrudAppService<TEntityDto>
        : ICrudAppService<TEntityDto, int>
    {

    }
}