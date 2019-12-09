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
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using MyAbpZeroProject.Authorization.Roles;
using MyAbpZeroProject.MultiTenancy;

namespace MyAbpZeroProject.Users
{
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
            ILocalizationManager localizationManager,
            IdentityEmailMessageService emailService,
            ISettingManager settingManager,
            IUserTokenProviderAccessor userTokenProviderAccessor)
            : base(userStore, roleManager, permissionManager, unitOfWorkManager, cacheManager, organizationUnitRepository, userOrganizationUnitRepository, organizationUnitSettings, localizationManager, emailService, settingManager, userTokenProviderAccessor)
        {
        }
    }
}