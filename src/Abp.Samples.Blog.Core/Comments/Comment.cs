using Abp.Domain.Entities.Auditing;
using Abp.Samples.Blog.Auth;

namespace Abp.Samples.Blog.Comments
{
    public class Comment : CreationAuditedEntity<int, BlogUser>
    {
        public virtual string Content { get; set; }
    }
}