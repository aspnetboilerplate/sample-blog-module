using Abp.Application.Features;
using Abp.MultiTenancy;
using Abp.Samples.Blog.Domain.Repositories;
using Abp.Samples.Blog.Editions;

namespace Abp.Samples.Blog.Auth
{
    public class BlogTenantManager : AbpTenantManager<BlogTenant, BlogUser>
    {
        public BlogTenantManager(
            ISampleBlogRepository<BlogTenant> tenantRepository, 
            ISampleBlogRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            BlogEditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore)
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}