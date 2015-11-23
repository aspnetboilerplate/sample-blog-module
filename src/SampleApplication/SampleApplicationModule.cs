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
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                userRepository,
                userLoginRepository,
                userRoleRepository,
                roleRepository,
                userPermissionSettingRepository,
                unitOfWorkManager)
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
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
            : base(
                roleRepository,
                userRoleRepository,
                rolePermissionSettingRepository)
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
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager)
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
        public EditionManager(IRepository<Edition> editionRepository, IRepository<EditionFeatureSetting, long> editionFeatureRepository) : base(editionRepository, editionFeatureRepository)
        {
        }
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
