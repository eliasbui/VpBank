using Application.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Model.Request;

namespace API.Controllers.Version._1._0;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
[ApiVersion("2")]
public class VpBankController : ControllerBase
{
    private readonly IVpBankService _vpBankService;

    public VpBankController(IVpBankService vpBankService)
    {
        _vpBankService = vpBankService;
    }
    [HttpGet("get-all-vp-bank-customer")]
    [MapToApiVersion("1")]
    public async Task<IActionResult> GetAllVpBankCustomer()
    {
        var result = await _vpBankService.GetAllVpBankCustomer();
        return StatusCode(result.StatusCode, result);
    }
    [HttpPost("create-vp-bank-customer")]
    [MapToApiVersion("1")]
    public async Task<IActionResult> CreateVpBankCustomer(CreateVpBankCustomerModel vpBankCustomer)
    {
        var result = await _vpBankService.CreateVpBankCustomer(vpBankCustomer);
        return StatusCode(result.StatusCode, result);
    }
    [HttpPost("create-email-log")]
    [MapToApiVersion("1")]
    public async Task<IActionResult> CreateEmailLog(CreateLogEmailModel emailLog)
    {
        var result = await _vpBankService.CreateEmailLog(emailLog);
        return StatusCode(result.StatusCode, result);
    }
    [HttpGet("get-log-email-by-id-vp-bank-customer/{id}")]
    [MapToApiVersion("1")]
    public async Task<IActionResult> GetLogEmailByIdVpBankCustomer(Guid id)
    {
        var result = await _vpBankService.GetLogEmailByIdVpBankCustomer(id);
        return StatusCode(result.StatusCode, result);
    }
    [HttpDelete("delete-vp-bank-customer/{id}")]
    [MapToApiVersion("1")]
    public async Task<IActionResult> DeleteVpBankCustomer(Guid id)
    {
        var result = await _vpBankService.DeleteVpBankCustomer(id);
        return StatusCode(result.StatusCode, result);
    }
    [HttpDelete("delete-log-email-by-id-vp-bank-customer/{id}")]
    [MapToApiVersion("1")]
    public async Task<IActionResult> DeleteLogEmailByIdVpBankCustomer(Guid id)
    {
        var result = await _vpBankService.DeleteLogEmailByIdVpBankCustomer(id);
        return StatusCode(result.StatusCode, result);
    }
}