using System;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task Should_Get_Posts()
        {
            var posts = await _postAppService.GetPosts(new GetPostsInput());
            posts.TotalCount.ShouldBe(2);
            posts.Items.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Get_Posts_With_Parameter()
        {
            var posts = await _postAppService.GetPosts(new GetPostsInput()
            {
                MaxResultCount = 1000
            });
            posts.TotalCount.ShouldBe(2);
            posts.Items.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Insert_Post()
        {
            var title = Guid.NewGuid().ToString();

            await _postAppService.CreatePost(
                new CreatePostInput
                {
                    CategoryId = 1,
                    Content = "a test content",
                    Title = title,
                    Status = PostStatus.Draft,
                    Tags = "test tags"
                });

            UsingDbContext(context => { context.Posts.FirstOrDefault(p => p.Title == title).ShouldNotBe(null); });
        }
    }
}
