using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Samples.Blog.Domain.Repositories;

namespace Abp.Samples.Blog.Editions
{
    public class BlogEditionManager : AbpEditionManager
    {
        public BlogEditionManager(
            ISampleBlogRepository<Edition> editionRepository,
            IAbpZeroFeatureValueStore featureValueStore)
            : base(
                editionRepository,
                featureValueStore)
        {
        }
    }
}