using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using Abp.Samples.Blog.Domain.Repositories;
using Abp.Zero.Configuration;

namespace Abp.Samples.Blog.Auth
{
    public class BlogUserManager : AbpUserManager<BlogTenant, BlogRole, BlogUser>
    {
        public BlogUserManager(
            BlogUserStore store,
            BlogRoleManager blogRoleManager,
            ISampleBlogRepository<BlogTenant> tenantRepository,
            IMultiTenancyConfig multiTenancyConfig,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            ICacheManager cacheManager)
            : base(
                store,
                blogRoleManager,
                tenantRepository,
                multiTenancyConfig,
                permissionManager,
                unitOfWorkManager,
                settingManager,
                userManagementConfig,
                iocResolver,
                cacheManager)
        {
        }
    }
}