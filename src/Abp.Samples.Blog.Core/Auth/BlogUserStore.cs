using Abp.Authorization.Users;
using Abp.Domain.Uow;
using Abp.Samples.Blog.Domain.Repositories;

namespace Abp.Samples.Blog.Auth
{
    public class BlogUserStore : AbpUserStore<BlogRole, BlogUser>
    {
        public BlogUserStore(
            ISampleBlogRepository<BlogUser, long> userRepository,
            ISampleBlogRepository<UserLogin, long> userLoginRepository,
            ISampleBlogRepository<UserRole, long> userRoleRepository,
            ISampleBlogRepository<BlogRole> roleRepository,
            ISampleBlogRepository<UserPermissionSetting, long> userPermissionSettingRepository,
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
}