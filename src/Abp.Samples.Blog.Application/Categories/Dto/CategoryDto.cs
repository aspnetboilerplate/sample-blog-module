using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Abp.Samples.Blog.Categories
{
    [AutoMap(typeof(Category))]
    public class CategoryDto : EntityRequestInput
    {
        [Required]
        [StringLength(Category.MaxNameLength)]
        public virtual string Name { get; set; }
    }
}