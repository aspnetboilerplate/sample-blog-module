using Abp.MultiTenancy;
using Abp.Samples.Blog.Domain.Repositories;
using Abp.Samples.Blog.Editions;

namespace Abp.Samples.Blog.Auth
{
    public class BlogTenantManager : AbpTenantManager<BlogTenant, BlogRole, BlogUser>
    {
        public BlogTenantManager(
            ISampleBlogRepository<BlogTenant> tenantRepository, 
            ISampleBlogRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            BlogEditionManager editionManager)
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager)
        {
        }
    }
}