using Abp.Samples.Blog.Posts;
using Abp.Samples.Blog.Posts.Dtos;
using Shouldly;
using Xunit;

namespace Abp.Samples.Blog.Tests.Posts
{
    public class PostAppService_Tests : SampleBlogTestBase
    {
        private readonly IPostAppService _postAppService;

        public PostAppService_Tests()
        {
            _postAppService = Resolve<IPostAppService>();
        }

        [Fact]
        public void Should_Get_Posts()
        {
            var posts = _postAppService.GetPosts(new GetPostsInput());
            posts.TotalCount.ShouldBe(2);
            posts.Items.Count.ShouldBe(2);
        }
    }
}
