using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;

namespace Abp.Samples.Blog.Auth
{
    public class RoleStore : AbpRoleStore<BlogTenant, BlogRole, BlogUser>
    {
        public RoleStore(
            IRepository<BlogRole> roleRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository,
            ICacheManager cacheManager)
            : base(
                roleRepository,
                userRoleRepository,
                rolePermissionSettingRepository,
                cacheManager)
        {
        }
    }
}