using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Samples.Blog.Auth;
using Abp.Samples.Blog.Categories;

namespace Abp.Samples.Blog.Posts
{
    public class Post : FullAuditedEntity<int, BlogUser>
    {
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual int CategoryId { get; set; }

        public virtual string Title { get; set; }
        
        public virtual string Content { get; set; }
        
        public virtual string Tags { get; set; }
        
        public virtual PostStatus Status { get; set; }
    }
}