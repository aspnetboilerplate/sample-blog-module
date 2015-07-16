using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Abp.Samples.Blog.Application.Dtos
{
    public class DefaultPagedResultRequest : IPagedResultRequest
    {
        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public DefaultPagedResultRequest()
        {
            MaxResultCount = 10;
        }
    }
}