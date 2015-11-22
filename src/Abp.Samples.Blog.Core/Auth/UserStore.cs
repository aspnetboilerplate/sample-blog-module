using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;

namespace Abp.Samples.Blog.Auth
{
    public class UserStore : AbpUserStore<BlogTenant, BlogRole, BlogUser>
    {
        public UserStore(
            IRepository<BlogUser, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<BlogRole> roleRepository,
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
}