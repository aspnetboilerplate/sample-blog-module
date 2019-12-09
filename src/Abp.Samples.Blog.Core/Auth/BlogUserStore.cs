using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
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
            IUnitOfWorkManager unitOfWorkManager,
            ISampleBlogRepository<UserClaim, long> userClaimRepository,
            ISampleBlogRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            ISampleBlogRepository<OrganizationUnitRole, long> organizationUnitRoleRepository)
            : base(userRepository, userLoginRepository, userRoleRepository, roleRepository, userPermissionSettingRepository, unitOfWorkManager, userClaimRepository, userOrganizationUnitRepository, organizationUnitRoleRepository)
        {
        }
    }
}