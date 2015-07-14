using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Samples.Blog.Posts.Dtos;

namespace Abp.Samples.Blog.Posts
{
    public interface IPostAppService : IApplicationService
    {
        PagedResultOutput<PostDto> GetPosts(GetPostsInput input);
    }
}