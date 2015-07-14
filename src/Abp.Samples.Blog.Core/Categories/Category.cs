using Abp.Domain.Entities.Auditing;
using Abp.Samples.Blog.Auth;

namespace Abp.Samples.Blog.Categories
{
    public class Category : CreationAuditedEntity<int, BlogUser>
    {
        public virtual string Name { get; set; }
    }
}