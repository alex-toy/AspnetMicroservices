using Articles.API.Entities;

namespace Articles.API.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAll();

        Task<Article> Get(string id);

        Task<IEnumerable<Article>> GetByName(string name);

        Task<IEnumerable<Article>> GetByCategory(string categoryName);

        Task Create(Article product);

        Task<bool> Update(Article product);

        Task<bool> Delete(string id);
    }
}
