using Abp.Samples.Blog.Application.Services;
using Abp.Samples.Blog.Categories.Dto;

namespace Abp.Samples.Blog.Categories
{
    public interface ICategoryAppService : ICrudAppService<CategoryDto>
    {

    }
}