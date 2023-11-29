using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace DistributedSystems
{
    [Route("api/links")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public LinkController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<long> Create([FromBody] LinkRequest link)
        {
            var entity = await _appDbContext.Links.AddAsync(new Link(link.Url));
            await _appDbContext.SaveChangesAsync();
            return entity.Entity.Id;
        }

        [HttpGet("{id}")]
        public async Task<string> Get(long id)
        {
            var link = _appDbContext.Set<Link>().SingleOrDefault(x => x.Id == id);
            return link.Url;
        }
    }
}