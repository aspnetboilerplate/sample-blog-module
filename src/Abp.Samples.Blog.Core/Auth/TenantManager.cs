using Abp.MultiTenancy;
using Abp.Samples.Blog.Editions;

namespace Abp.Samples.Blog.Auth
{
    public class TenantManager : AbpTenantManager<BlogTenant, BlogRole, BlogUser>
    {
        public TenantManager(EditionManager editionManager)
            : base(editionManager)
        {

        }
    }
}