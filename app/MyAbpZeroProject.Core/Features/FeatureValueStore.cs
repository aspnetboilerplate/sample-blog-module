using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Runtime.Caching;
using MyAbpZeroProject.Authorization.Roles;
using MyAbpZeroProject.MultiTenancy;
using MyAbpZeroProject.Users;

namespace MyAbpZeroProject.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, User>
    {
        public FeatureValueStore(
            ICacheManager cacheManager,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
            IRepository<Tenant> tenantRepository,
            IRepository<EditionFeatureSetting, long> editionFeatureRepository,
            IFeatureManager featureManager,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                  cacheManager,
                  tenantFeatureRepository,
                  tenantRepository,
                  editionFeatureRepository,
                  featureManager,
                  unitOfWorkManager
                  )
        {
        }
    }
}
