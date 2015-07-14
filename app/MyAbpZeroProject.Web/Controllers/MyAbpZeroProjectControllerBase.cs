using Abp.Web.Mvc.Controllers;

namespace MyAbpZeroProject.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class MyAbpZeroProjectControllerBase : AbpController
    {
        protected MyAbpZeroProjectControllerBase()
        {
            LocalizationSourceName = MyAbpZeroProjectConsts.LocalizationSourceName;
        }
    }
}