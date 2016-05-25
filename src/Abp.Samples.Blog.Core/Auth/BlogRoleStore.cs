using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Samples.Blog.Domain.Repositories;

namespace Abp.Samples.Blog.Auth
{
    public class BlogRoleStore : AbpRoleStore<BlogRole, BlogUser>
    {
        public BlogRoleStore(
            ISampleBlogRepository<BlogRole> roleRepository,
            ISampleBlogRepository<UserRole, long> userRoleRepository,
            ISampleBlogRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
            : base(
                roleRepository,
                userRoleRepository,
                rolePermissionSettingRepository)
        {
        }
    }
}