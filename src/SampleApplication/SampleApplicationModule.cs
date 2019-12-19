using System.Data.Common;
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
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Samples.Blog;
using Abp.Samples.Blog.Domain.Repositories;
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
        public override void PreInitialize()
        {
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof (Tenant);
            Configuration.Modules.Zero().EntityTypes.User = typeof (User);
            Configuration.Modules.Zero().EntityTypes.Role = typeof (Role);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }

    public class User : AbpUser<User>
    {

    }

    public class Role : AbpRole<User>
    {

    }

    public class Tenant : AbpTenant<User>
    {

    }

    public class UserStore : AbpUserStore<Role, User>
    {
        public UserStore(
            ISampleBlogRepository<User, long> userRepository,
            ISampleBlogRepository<UserLogin, long> userLoginRepository,
            ISampleBlogRepository<UserRole, long> userRoleRepository,
            ISampleBlogRepository<Role> roleRepository,
            ISampleBlogRepository<UserPermissionSetting, long> userPermissionSettingRepository, 
            IUnitOfWorkManager unitOfWorkManager, 
            ISampleBlogRepository<UserClaim, long> userClaimRepository,
            ISampleBlogRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            ISampleBlogRepository<OrganizationUnitRole, long> organizationUnitRoleRepository) 
            : base(userRepository, userLoginRepository, userRoleRepository, roleRepository, userPermissionSettingRepository, unitOfWorkManager, userClaimRepository, userOrganizationUnitRepository, organizationUnitRoleRepository)
        {
        }
    }

    public class UserManager : AbpUserManager<Role, User>
    {
        public UserManager(
            UserStore userStore,
            RoleManager roleManager,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ICacheManager cacheManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IOrganizationUnitSettings organizationUnitSettings,
            IdentityEmailMessageService emailService,
            ILocalizationManager localizationManager,
            ISettingManager settingManager,
            IUserTokenProviderAccessor userTokenProviderAccessor)
            : base(
                userStore,
                roleManager,
                permissionManager,
                unitOfWorkManager,
                cacheManager,
                organizationUnitRepository,
                userOrganizationUnitRepository,
                organizationUnitSettings,
                localizationManager,
                emailService,
                settingManager,
                userTokenProviderAccessor)
        {
        }
    }

    public class RoleStore : AbpRoleStore<Role, User>
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

    public class RoleManager : AbpRoleManager<Role, User>
    {
        public RoleManager(
            RoleStore store,
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            ICacheManager cacheManager,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository) 
            : base(store, permissionManager, roleManagementConfig, cacheManager, unitOfWorkManager, organizationUnitRepository, organizationUnitRoleRepository)
        {
        }
    }

    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }

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

    public class EditionManager : AbpEditionManager
    {
        public EditionManager(
            IRepository<Edition> editionRepository,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                  editionRepository,
                  featureValueStore)
        {
        }
    }

    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }

    public class SampleApplicationDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* NOTE: 
        *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
        *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
        *   pass connection string name to base classes. ABP works either way.
        */
        public SampleApplicationDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in AbpProjectNameDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of AbpProjectNameDbContext since ABP automatically handles it.
         */
        public SampleApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SampleApplicationDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
