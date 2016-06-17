using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {
    }

    public class PostCategoryReository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryReository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}