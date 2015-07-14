using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Samples.Blog.Auth;

namespace Abp.Samples.Blog.Comments
{
    [Table("BlgComments")]
    public class Comment : CreationAuditedEntity<int, BlogUser>
    {
        public const int MaxContentLength = 2000;

        [Required]
        [StringLength(MaxContentLength)]
        public virtual string Content { get; set; }
    }
}