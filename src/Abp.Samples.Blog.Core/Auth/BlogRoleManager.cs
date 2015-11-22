using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;

namespace Abp.Samples.Blog.Auth
{
    public class BlogRoleManager : AbpRoleManager<BlogTenant, BlogRole, BlogUser>
    {
        public BlogRoleManager(
            BlogRoleStore store,
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            ICacheManager cacheManager)
            : base(
                store,
                permissionManager,
                roleManagementConfig,
                cacheManager)
        {
        }
    }
}