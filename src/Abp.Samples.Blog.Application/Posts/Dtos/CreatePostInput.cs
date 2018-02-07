using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Abp.Samples.Blog.Posts.Dtos
{
    [AutoMapTo(typeof(Post))]
    public class CreatePostInput
    {
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(Post.MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Tags { get; set; }

        public PostStatus Status { get; set; }
    }
}