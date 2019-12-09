using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using MyAbpZeroProject.Authorization.Roles;
using MyAbpZeroProject.Editions;
using MyAbpZeroProject.Users;

namespace MyAbpZeroProject.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore)
            : base(tenantRepository, tenantFeatureRepository, editionManager, featureValueStore)
        {
        }
    }
}