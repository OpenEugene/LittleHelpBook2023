using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using OE.Module.LHB.Repository;
using Oqtane.Controllers;
using System.Net;
using M = OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Controllers;

[Route(ControllerRoutes.ApiRoute)]
public class PhoneNumberController : ModuleControllerBase
{
    private readonly LHBRepository _lhbRepository;

    public PhoneNumberController(LHBRepository lhbRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor) { _lhbRepository = lhbRepository; }

    // POST api/<controller>
    [HttpPost]
    public M.PhoneNumber Post([FromBody] M.PhoneNumber item)
    {
        if (ModelState.IsValid)
        {
            item = _lhbRepository.AddPhoneNumber(item);
            _logger.Log(LogLevel.Information, this, LogFunction.Create, "PhoneNumber Added {item}", item);
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
        var item = _lhbRepository.GetPhoneNumberByPhoneNumberId(id);
        if (item != null)
        {
            _lhbRepository.DeletePhoneNumber(id);
            _logger.Log(LogLevel.Information, this, LogFunction.Delete, "PhoneNumber Deleted {id}", id);
        }
        else
        {
            _logger.Log(LogLevel.Error, this, LogFunction.Security, "Bad PhoneNumber Delete Attempt {id}", id);
            HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}