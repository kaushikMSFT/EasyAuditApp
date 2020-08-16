using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditorAPI.Contracts;
using AuditorAPI.Domain;
using AuditorAPI.Domain;
using AuditorAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuditorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditPortfolioController : ControllerBase
    {
        private readonly IAuditPortfolioService _auditPortfolioService;
        public AuditPortfolioController(IAuditPortfolioService auditPorfolioService)
        {
            _auditPortfolioService = auditPorfolioService;
        }
        // GET: api/<AuditPortfolioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuditPortfolioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuditPortfolioController>
        [HttpPost]
        public void Post([FromBody] AuditPortfolioCreationRequest auditPortfolioCreationRequest)
        {
            //_auditPortfolioService.Create(new AuditPortfolio() { client = new ClientProfile() { id = auditPortfolioCreationRequest.ClientId }, ReportReleaseDate = auditPortfolioCreationRequest.ReportReleaseDate });
        }

        // PUT api/<AuditPortfolioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuditPortfolioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
