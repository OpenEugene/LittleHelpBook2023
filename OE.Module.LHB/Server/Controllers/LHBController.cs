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

namespace OE.Module.LHB.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class LHBController : ModuleControllerBase
    {
        private readonly ILHBRepository _LHBRepository;

        public LHBController(ILHBRepository LHBRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _LHBRepository = LHBRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.LHB> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _LHBRepository.GetLHBs(ModuleId);
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
        public Models.LHB Get(int id)
        {
            Models.LHB LHB = _LHBRepository.GetLHB(id);
            if (LHB != null && IsAuthorizedEntityId(EntityNames.Module, LHB.ModuleId))
            {
                return LHB;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LHB Get Attempt {LHBId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.LHB Post([FromBody] Models.LHB LHB)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, LHB.ModuleId))
            {
                LHB = _LHBRepository.AddLHB(LHB);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "LHB Added {LHB}", LHB);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LHB Post Attempt {LHB}", LHB);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                LHB = null;
            }
            return LHB;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.LHB Put(int id, [FromBody] Models.LHB LHB)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, LHB.ModuleId) && _LHBRepository.GetLHB(LHB.LHBId, false) != null)
            {
                LHB = _LHBRepository.UpdateLHB(LHB);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "LHB Updated {LHB}", LHB);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LHB Put Attempt {LHB}", LHB);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                LHB = null;
            }
            return LHB;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.LHB LHB = _LHBRepository.GetLHB(id);
            if (LHB != null && IsAuthorizedEntityId(EntityNames.Module, LHB.ModuleId))
            {
                _LHBRepository.DeleteLHB(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "LHB Deleted {LHBId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized LHB Delete Attempt {LHBId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
