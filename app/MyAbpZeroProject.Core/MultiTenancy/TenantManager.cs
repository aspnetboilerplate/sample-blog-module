using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using MyAbpZeroProject.Authorization.Roles;
using MyAbpZeroProject.Users;

namespace MyAbpZeroProject.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(IRepository<Tenant> tenantRepository)
            : base(tenantRepository)
        {

        }
    }
}