using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;

namespace Abp.Samples.Blog.Auth
{
    //public class UserManager : AbpUserManager<BlogTenant, BlogRole, BlogUser>
    //{
    //    public UserManager(
    //        UserStore store,
    //        RoleManager roleManager,
    //        IRepository<BlogTenant> tenantRepository,
    //        IMultiTenancyConfig multiTenancyConfig,
    //        IPermissionManager permissionManager,
    //        IUnitOfWorkManager unitOfWorkManager,
    //        ISettingManager settingManager,
    //        IUserManagementConfig userManagementConfig,
    //        IIocResolver iocResolver)
    //        : base(
    //            store,
    //            roleManager,
    //            tenantRepository,
    //            multiTenancyConfig,
    //            permissionManager,
    //            unitOfWorkManager,
    //            settingManager,
    //            userManagementConfig,
    //            iocResolver)
    //    {
    //    }
    //}
}