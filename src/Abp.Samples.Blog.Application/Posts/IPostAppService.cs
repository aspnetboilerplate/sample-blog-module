using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Samples.Blog.Posts.Dtos;

namespace Abp.Samples.Blog.Posts
{
    public interface IPostAppService : IApplicationService
    {
        Task<PagedResultDto<PostDto>> GetPosts(GetPostsInput input);

        Task CreatePost(CreatePostInput input);
    }
}