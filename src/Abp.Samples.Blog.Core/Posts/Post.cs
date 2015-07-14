using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Samples.Blog.Auth;
using Abp.Samples.Blog.Categories;

namespace Abp.Samples.Blog.Posts
{
    [Table("BlgPosts")]
    public class Post : FullAuditedEntity<int, BlogUser>
    {
        public const int MaxTitleLength = 128;

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual int CategoryId { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string Title { get; set; }

        [Required]
        public virtual string Content { get; set; }
        
        public virtual string Tags { get; set; }
        
        public virtual PostStatus Status { get; set; }

        public Post()
        {
            Status = PostStatus.Draft;
        }
    }
}