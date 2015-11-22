using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Samples.Blog.Auth;

namespace Abp.Samples.Blog.Editions
{
    public class EditionManager : AbpEditionManager
    {
        
    }

    public class FeatureValueStore : AbpFeatureValueStore<BlogTenant, BlogRole, BlogUser>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {

        }
    }
}