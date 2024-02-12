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
using OE.Module.LHB.Shared.ViewModels;
using OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class ProviderController : ModuleControllerBase
    {
        private readonly LHBRepository _lhbRepository;

        public ProviderController(LHBRepository lhbRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _lhbRepository = lhbRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        public IEnumerable<M.Provider> Get()
        {
            try { 
                var list = _lhbRepository.GetProviders();
                return list;
            }
            catch (System.Exception ex)
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, ex, "Get Providers Failed");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return null;
            }
           
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public M.Provider Get(int id)
        {
            M.Provider item = _lhbRepository.GetProvider(id);
            return item;
        }

        // GET api/<controller>/5
        [HttpGet("vm/{id}")]
       // [Authorize(Policy = PolicyNames.ViewModule)]
        public ActionResult<ProviderViewModel> GetVM(int id)
        {
            var item = _lhbRepository.GetProviderViewModel(id);
            if (item == null) { 
                return NotFound();
            }
            return Ok(item);
        }

        // GET api/<controller>/5
        [HttpGet("ProviderAttributes/{id}")]
        // [Authorize(Policy = PolicyNames.ViewModule)]
        public ActionResult<List<ProviderViewModel>> GetProviderAttributes(int id)
        {
            var item = _lhbRepository.GetProviderAttributesByProviderId(id);
            return Ok(item);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public M.Provider Post([FromBody] M.Provider item)
        {
            if (ModelState.IsValid )
            {
                item = _lhbRepository.AddProvider(item);
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
            if (ModelState.IsValid && _lhbRepository.GetProvider(item.ProviderId, false) != null)
            {
                item = _lhbRepository.UpdateProvider(item);
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

        // PUT api/<controller>/5
        [HttpPut("vm/{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public ProviderViewModel PutVm(int id, [FromBody] ProviderViewModel item)
        {
            if (ModelState.IsValid)
            {
                item = _lhbRepository.UpdateProvider(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Provider Updated {item}", item);
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
            M.Provider item = _lhbRepository.GetProvider(id);
            if (item != null )
            {
                _lhbRepository.DeleteProvider(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Provider Deleted {id}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Bad Provider Delete Attempt {id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public M.Address Post([FromBody] M.Address item)
        {
            if (ModelState.IsValid)
            {
                item = _lhbRepository.AddAddress(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Address Added {item}", item);
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                item = null;
            }
            return item;
        } // POST api/<controller>
        [HttpPost("ProviderAttribute")]
        public M.ProviderAttribute Post([FromBody] M.ProviderAttribute item)
        {
            if (ModelState.IsValid)
            {
             
                item = _lhbRepository.AddProviderAttribute(item);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "ProviderAttribute Added {item}", item);
            }
            else
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                item = null;
            }
            return item;
        }
    }
}
