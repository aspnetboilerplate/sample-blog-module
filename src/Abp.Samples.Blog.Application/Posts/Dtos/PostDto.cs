using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Abp.Samples.Blog.Posts.Dtos
{
    [AutoMapFrom(typeof(Post))]
    public class PostDto : EntityDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Tags { get; set; }

        public PostStatus Status { get; set; }
    }
}