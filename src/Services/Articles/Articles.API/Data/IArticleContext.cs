using Articles.API.Entities;
using MongoDB.Driver;

namespace Articles.API.Data
{
    public interface IArticleContext
    {
        IMongoCollection<Article> Articles { get; }
    }
}