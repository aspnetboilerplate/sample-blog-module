using Abp.Authorization.Users;
using MyAbpZeroProject.MultiTenancy;

namespace MyAbpZeroProject.Users
{
    public class User : AbpUser<Tenant, User>
    {

    }
}