using Abp.Samples.Blog.Application.Dtos;
using Abp.Samples.Blog.Categories;
using Shouldly;
using Xunit;

namespace Abp.Samples.Blog.Tests.Categories
{
    public class CategoryAppService_Tests : SampleBlogTestBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryAppService_Tests()
        {
            _categoryAppService = Resolve<ICategoryAppService>();
        }

        [Fact]
        public void Should_Get_All_Categories()
        {
            var output = _categoryAppService.GetAll(new DefaultPagedResultRequest());
            output.Items.Count.ShouldBe(2);
            output.TotalCount.ShouldBe(2);
        }
    }
}
