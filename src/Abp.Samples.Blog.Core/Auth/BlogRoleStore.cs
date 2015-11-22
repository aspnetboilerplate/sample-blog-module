using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Abp.Samples.Blog.Domain.Repositories;

namespace Abp.Samples.Blog.Auth
{
    public class BlogRoleStore : AbpRoleStore<BlogTenant, BlogRole, BlogUser>
    {
        public BlogRoleStore(
            ISampleBlogRepository<BlogRole> roleRepository,
            ISampleBlogRepository<UserRole, long> userRoleRepository,
            ISampleBlogRepository<RolePermissionSetting, long> rolePermissionSettingRepository,
            ICacheManager cacheManager)
            : base(
                roleRepository,
                userRoleRepository,
                rolePermissionSettingRepository,
                cacheManager)
        {
        }
    }
}