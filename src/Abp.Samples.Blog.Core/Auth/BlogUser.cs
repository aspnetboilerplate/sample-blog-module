using Abp.Authorization.Users;

namespace Abp.Samples.Blog.Auth
{
    public class BlogUser : AbpUser<BlogTenant, BlogUser>
    {

    }
}