using Abp.MultiTenancy;
using Abp.Samples.Blog.Editions;

namespace Abp.Samples.Blog.Auth
{
    public class BlogTenantManager : AbpTenantManager<BlogTenant, BlogRole, BlogUser>
    {
        public BlogTenantManager(BlogEditionManager blogEditionManager)
            : base(blogEditionManager)
        {

        }
    }
}