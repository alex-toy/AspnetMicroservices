using Articles.API.Entities;
using MongoDB.Driver;

namespace Articles.API.Data
{
    public class ArticleContext : IArticleContext
    {
        public ArticleContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("MongoSettings:DatabaseName"));

            Articles = database.GetCollection<Article>(configuration.GetValue<string>("MongoSettings:CollectionName"));
            ArticleContextSeed.SeedData(Articles);
        }

        public IMongoCollection<Article> Articles { get; }
    }
}
