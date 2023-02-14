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
    public class ResourceController : ModuleControllerBase
    {
        private readonly ResourceRepository _repository;

        public ResourceController(ResourceRepository repository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _repository = repository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Resource> Get()
        {         
                return _repository.GetResources();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Resource Get(int id)
        {
            Models.Resource LHB = _repository.GetResource(id);
                return LHB;
          
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Resource Post([FromBody] Models.Resource resource)
        {
            if (ModelState.IsValid) {
                resource = _repository.AddResource(resource);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Resource Added {resource}", resource);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized resource Post Attempt {resource}", resource);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                resource = null;
            }
            return resource;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Resource Put(int id, [FromBody] Models.Resource resource)
        {
            if (ModelState.IsValid) 
            {
                resource = _repository.UpdateResource(resource);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Resource Updated {LHB}", resource);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Resource Put Attempt {resource}", resource);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                resource = null;
            }
            return resource;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Resource resource = _repository.GetResource(id);
            if (resource != null )
            {
                _repository.DeleteResource(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "resource Deleted {id}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized resource Delete Attempt {id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
