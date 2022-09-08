namespace Service_Provider.Controllers;

using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service_Provider.Controllers.Models.Requests;
using Service_Provider.Domain.Contracts;
using Service_Provider.Domain.Models;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    IValidator<ServiceRequest> servicePostValidator;
    public IServiceDomain _serviceDomain { get; set; }
    public ServiceController(IServiceDomain serviceDomain, IValidator<ServiceRequest> servicePostValidator)
    {
        this._serviceDomain = serviceDomain;
        this.servicePostValidator = servicePostValidator;
    }

    // GET: api/<ServiceController>
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_serviceDomain.GetAllServices());
    }

    // POST api/<ServiceController>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostAsync([FromBody] ServiceRequest request)
    {
        ValidationResult validation = await servicePostValidator.ValidateAsync(request);
        if (validation.IsValid)
        {
            return Ok(_serviceDomain.AddService(new ServiceDTO(request.name, request.price)));
        }
        else
        {
            return BadRequest(validation.Errors);
        }
    }
}

