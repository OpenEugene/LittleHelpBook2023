using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using OE.Module.LHB.Repository;
using Oqtane.Controllers;
using System.Net;

using M = OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class ProviderController : ModuleControllerBase
    {
        private readonly ProviderRepository _providerRepository;

        public ProviderController(ProviderRepository providerRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _providerRepository = providerRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<M.Provider> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _providerRepository.GetLHBs(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LHB Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public M.Provider Get(int id)
        {
            M.Provider item = _providerRepository.GetProvider(id);
            return item;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public M.Provider Post([FromBody] M.Provider item)
        {
            if (ModelState.IsValid )
            {
                item = _providerRepository.AddLHB(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Provider Added {item}", item);
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                item = null;
            }
            return item;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public M.Provider Put(int id, [FromBody] M.Provider item)
        {
            if (ModelState.IsValid && _providerRepository.GetProvider(item.ProviderId, false) != null)
            {
                item = _providerRepository.UpdateLHB(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Provider Updated {item}",item);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Bad Provider Put Attempt {item}", item);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                item = null;
            }
            return item;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            M.Provider item = _providerRepository.GetProvider(id);
            if (item != null )
            {
                _providerRepository.DeleteLHB(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Provider Deleted {id}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Bad Provider Delete Attempt {id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
