using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using OE.LHB.Repository;
using Oqtane.Controllers;
using System.Net;

namespace OE.LHB.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class ProviderController : ModuleControllerBase
    {
        private readonly ProviderRepository _repository;

        public ProviderController(ProviderRepository repository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _repository = repository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Provider> Get()
        {         
                return _repository.GetProviders();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Provider Get(int id)
        {
            Models.Provider LHB = _repository.GetProvider(id);
                return LHB;
          
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Provider Post([FromBody] Models.Provider provider)
        {
            if (ModelState.IsValid) {
                provider = _repository.AddProvider(provider);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "LHB Added {provider}", provider);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized provider Post Attempt {provider}", provider);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                provider = null;
            }
            return provider;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Provider Put(int id, [FromBody] Models.Provider provider)
        {
            if (ModelState.IsValid) 
            {
                provider = _repository.UpdateProvider(provider);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "LHB Updated {LHB}", provider);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LHB Put Attempt {provider}", provider);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                provider = null;
            }
            return provider;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Provider provider = _repository.GetProvider(id);
            if (provider != null )
            {
                _repository.DeleteProvider(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "provider Deleted {id}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized provider Delete Attempt {id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
