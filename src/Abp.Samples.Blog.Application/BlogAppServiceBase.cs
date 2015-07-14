using Abp.Application.Services;

namespace Abp.Samples.Blog
{
    public abstract class BlogAppServiceBase : ApplicationService
    {
        protected BlogAppServiceBase()
        {
            //LocalizationSourceName = "AbpSampleBlog"; //TODO: Create a localization source
        }
    }
}