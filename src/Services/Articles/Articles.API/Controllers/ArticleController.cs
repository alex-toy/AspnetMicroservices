using Articles.API.Entities;
using Articles.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Articles.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _repository;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IArticleRepository repository, ILogger<ArticleController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Article>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Article>>> GetAll()
        {
            var articles = await _repository.GetAll();
            return Ok(articles);
        }

        [HttpGet("{id:length(24)}", Name = "Get")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Article), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Article>> Get(string id)
        {
            var articles = await _repository.Get(id);
            if (articles == null)
            {
                _logger.LogError($"Article with id: {id}, not found.");
                return NotFound();
            }
            return Ok(articles);
        }

        [Route("[action]/{category}", Name = "GetByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Article>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Article>>> GetByCategory(string category)
        {
            var articles = await _repository.GetByCategory(category);
            return Ok(articles);
        }

        [Route("[action]/{category}", Name = "GetByName")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Article>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Article>>> GetByName(string name)
        {
            var articles = await _repository.GetByName(name);
            return Ok(articles);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Article), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Article>> Create([FromBody] Article article)
        {
            await _repository.Create(article);

            return CreatedAtRoute("GetArticle", new { id = article.Id }, article);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Article), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] Article article)
        {
            return Ok(await _repository.Update(article));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Article), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}