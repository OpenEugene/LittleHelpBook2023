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
    public class AddressController : ModuleControllerBase
    {
        private readonly LHBRepository _lhbRepository;

        public AddressController(LHBRepository lhbRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _lhbRepository = lhbRepository;
        }

        // POST api/<controller>
        [HttpPost]
        public M.Address Post([FromBody] M.Address item)
        {
            if (ModelState.IsValid )
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
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _lhbRepository.GetAddressByAddressId(id);
            if (item != null )
            {
                _lhbRepository.DeleteAddress(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Address Deleted {id}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Bad Address Delete Attempt {id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
        }
    }
}
