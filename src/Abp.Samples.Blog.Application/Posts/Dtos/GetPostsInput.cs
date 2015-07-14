using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Abp.Samples.Blog.Posts.Dtos
{
    public class GetPostsInput : IPagedResultRequest
    {
        public const int DefaultPageSize = 10;

        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public GetPostsInput()
        {
            MaxResultCount = DefaultPageSize;
        }
    }
}