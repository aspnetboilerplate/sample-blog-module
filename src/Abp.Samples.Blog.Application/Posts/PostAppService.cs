using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Samples.Blog.Domain.Repositories;
using Abp.Samples.Blog.Posts.Dtos;

namespace Abp.Samples.Blog.Posts
{
    public class PostAppService : BlogAppServiceBase, IPostAppService
    {
        private readonly ISampleBlogRepository<Post> _postRepository;

        public PostAppService(ISampleBlogRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public PagedResultOutput<PostDto> GetPosts(GetPostsInput input)
        {
            var postCount = _postRepository.Count();
            var posts = _postRepository.GetAll().OrderByDescending(p => p.CreationTime).PageBy(input);

            return new PagedResultOutput<PostDto>(
                postCount,
                posts.MapTo<List<PostDto>>()
                );
        }
    }
}
