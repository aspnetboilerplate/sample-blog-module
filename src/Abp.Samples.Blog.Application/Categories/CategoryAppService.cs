using Abp.Samples.Blog.Application.Services;
using Abp.Samples.Blog.Categories.Dto;
using Abp.Samples.Blog.Domain.Repositories;

namespace Abp.Samples.Blog.Categories
{
    public class CategoryAppService : CrudAppService<Category, CategoryDto>, ICategoryAppService
    {
        public CategoryAppService(ISampleBlogRepository<Category> repository)
            : base(repository)
        {

        }
    }
}
