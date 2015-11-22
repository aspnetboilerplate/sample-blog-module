using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using Abp.Samples.Blog.Domain.Repositories;

namespace Abp.Samples.Blog.Auth
{
    public class BlogUserStore : AbpUserStore<BlogTenant, BlogRole, BlogUser>
    {
        public BlogUserStore(
            ISampleBlogRepository<BlogUser, long> userRepository,
            ISampleBlogRepository<UserLogin, long> userLoginRepository,
            ISampleBlogRepository<UserRole, long> userRoleRepository,
            ISampleBlogRepository<BlogRole> roleRepository,
            ISampleBlogRepository<UserPermissionSetting, long> userPermissionSettingRepository,
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