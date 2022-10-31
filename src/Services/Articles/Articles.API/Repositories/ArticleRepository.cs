using Articles.API.Data;
using Articles.API.Entities;
using MongoDB.Driver;

namespace Articles.API.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IArticleContext _context;

        public ArticleRepository(IArticleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(Article article)
        {
            await _context.Articles.InsertOneAsync(article);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Article> filter = Builders<Article>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.Articles.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Article> Get(string id)
        {
            return await _context.Articles.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _context.Articles.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetByCategory(string categoryName)
        {
            FilterDefinition<Article> filter = Builders<Article>.Filter.Eq(p => p.Category, categoryName);

            return await _context.Articles.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Article>> GetByName(string name)
        {
            FilterDefinition<Article> filter = Builders<Article>.Filter.Eq(p => p.Name, name);

            return await _context.Articles.Find(filter).ToListAsync();
        }

        public async Task<bool> Update(Article product)
        {
            var updateResult = await _context.Articles
                                        .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
