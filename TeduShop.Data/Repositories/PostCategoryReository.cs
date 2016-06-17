using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public class PostCategoryReository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryReository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IPostCategoryRepository
    {
    }
}