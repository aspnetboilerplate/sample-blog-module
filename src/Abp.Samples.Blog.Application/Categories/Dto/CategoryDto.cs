using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Abp.Samples.Blog.Categories.Dto
{
    [AutoMap(typeof(Category))]
    public class CategoryDto : EntityDto
    {
        [Required]
        [StringLength(Category.MaxNameLength)]
        public virtual string Name { get; set; }
    }
}