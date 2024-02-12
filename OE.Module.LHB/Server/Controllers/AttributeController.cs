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
using Oqtane.Models;

namespace OE.Module.LHB.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class AttributeController : ModuleControllerBase
    {
        private readonly LHBRepository _lhbRepository;

        public AttributeController(LHBRepository lhbRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _lhbRepository = lhbRepository;
        }


        // GET: api/<controller>?moduleid=x
        [HttpGet]
        public IEnumerable<M.Attribute> Get()
        {
            try
            {
                var list = _lhbRepository.GetAttributes();
                return list;
            }
            catch (System.Exception ex)
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, ex, "Get Attributes Failed");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return null;
            }

        }

    }
}
