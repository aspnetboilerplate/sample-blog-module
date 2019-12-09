using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Samples.Blog.Domain.Repositories;
using Abp.Zero.Configuration;

namespace Abp.Samples.Blog.Auth
{
    public class BlogRoleManager : AbpRoleManager<BlogRole, BlogUser>
    {
        public BlogRoleManager(
              BlogRoleStore store,
              IPermissionManager permissionManager,
              IRoleManagementConfig roleManagementConfig,
              ICacheManager cacheManager,
              IUnitOfWorkManager unitOfWorkManager,
              ISampleBlogRepository<OrganizationUnit, long> organizationUnitRepository,
              ISampleBlogRepository<OrganizationUnitRole, long> organizationUnitRoleRepository)
              : base(store, permissionManager, roleManagementConfig, cacheManager, unitOfWorkManager, organizationUnitRepository, organizationUnitRoleRepository)
        {
        }
    }
}