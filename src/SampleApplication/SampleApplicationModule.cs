using System.Reflection;
using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Runtime.Caching;
using Abp.Samples.Blog;
using Abp.Samples.Blog.EntityFramework;
using Abp.Zero.Configuration;
using Abp.Zero.EntityFramework;
using Microsoft.AspNet.Identity;

namespace SampleApplication
{
    [DependsOn(
        typeof (AbpSampleBlogApplicationModule),
        typeof(AbpSampleBlogEntityFrameworkModule))]
    public class SampleApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }

    public class User : AbpUser<Tenant, User>
    {

    }

    public class Role : AbpRole<Tenant, User>
    {

    }

    public class Tenant : AbpTenant<Tenant, User>
    {

    }

    public class UserStore : AbpUserStore<Tenant, Role, User>
    {
        public UserStore(
            IRepository<User, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role> roleRepository,
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ICacheManager cacheManager)
            : base(
                userRepository,
                userLoginRepository,
                userRoleRepository,
                roleRepository,
                userPermissionSettingRepository,
                unitOfWorkManager,
                cacheManager)
        {

        }
    }

    public class UserManager : AbpUserManager<Tenant, Role, User>
    {
        public UserManager(
            UserStore userStore,
            RoleManager roleManager,
            IRepository<Tenant> tenantRepository,
            IMultiTenancyConfig multiTenancyConfig,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            ICacheManager cacheManager
            )
            : base(
            userStore,
            roleManager,
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

    public class RoleStore : AbpRoleStore<Tenant, Role, User>
    {
        public RoleStore(
            IRepository<Role> roleRepository,
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

    public class RoleManager : AbpRoleManager<Tenant, Role, User>
    {
        public RoleManager(
            RoleStore store,
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

    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(EditionManager editionManager) :
            base(editionManager)
        {
        }
    }

    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {

        }
    }

    public class EditionManager : AbpEditionManager
    {
    }

    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }

    public class SampleApplicationDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //...
    }
}
