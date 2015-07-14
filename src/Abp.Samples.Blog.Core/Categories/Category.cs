using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Samples.Blog.Auth;

namespace Abp.Samples.Blog.Categories
{
    [Table("BlgCategories")]
    public class Category : CreationAuditedEntity<int, BlogUser>
    {
        public const int MaxNameLength = 128;

        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }
    }
}