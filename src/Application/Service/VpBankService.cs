using Application.Service.IService;
using Common.Base;
using Common.Extension;
using Infrastructure.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Model.Request;
using Model.Validator;
using Serilog.Events;

namespace Application.Service;

public class VpBankService : IVpBankService
{
    private readonly IUnitOfWork _ofWork;
    private readonly ILogger<VpBankService> _logger;
    private const string ClassName = nameof(VpBankService);

    public VpBankService(IUnitOfWork ofWork, ILogger<VpBankService> logger)
    {
        _ofWork = ofWork;
        _logger = logger;
    }

    public async Task<BaseResultApiResponse<dynamic>> GetAllVpBankCustomer()
    {
        try
        {
            _logger.LogInformation("Get all VpBank customer".GeneratedLog(ClassName, LogEventLevel.Information));
            var result = await _ofWork.VpBankRepository.GetAllVpBankCustomer();
            return result.Any()
                ? new BaseResultApiResponse<dynamic>()
                {
                    Success = true,
                    Result = result,
                    Message = "Get all VpBank customer successfully",
                    StatusCode = StatusCodes.Status200OK
                }
                : new BaseResultApiResponse<dynamic>()
                {
                    Success = false,
                    Result = null,
                    Message = "Get all VpBank customer failed",
                    StatusCode = StatusCodes.Status404NotFound
                };
        }
        catch (Exception e)
        {
            _logger.LogError("Get all VpBank customer failed".GeneratedLog(ClassName, LogEventLevel.Error));
            _logger.LogError(e.Message);
            return new BaseResultApiResponse<dynamic>()
            {
                Success = false,
                Result = null,
                Message = "Get all VpBank customer failed",
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    public async Task<BaseResultApiResponse<CreateVpBankCustomerModel>> CreateVpBankCustomer(
        CreateVpBankCustomerModel vpBankCustomer)
    {
        try
        {
            _logger.LogInformation("Check Validate VpBank customer".GeneratedLog(ClassName, LogEventLevel.Information));
            var validate = new VpBankCustomerValidator();
            var resultValidate = await validate.ValidateAsync(vpBankCustomer);
            if (resultValidate.Errors is { Count: > 0 })
                return new BaseResultApiResponse<CreateVpBankCustomerModel>()
                {
                    Success = false,
                    Message = resultValidate.Errors.First().ErrorMessage,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            _logger.LogInformation("Create VpBank customer".GeneratedLog(ClassName, LogEventLevel.Information));
            var result = await _ofWork.VpBankRepository.CreateVpBankCustomer(vpBankCustomer);
            return result
                ? new BaseResultApiResponse<CreateVpBankCustomerModel>()
                {
                    Success = true,
                    Result = new[]
                    {
                        vpBankCustomer
                    },
                    Message = "Create VpBank customer successfully",
                    StatusCode = StatusCodes.Status200OK
                }
                : new BaseResultApiResponse<CreateVpBankCustomerModel>()
                {
                    Success = false,
                    Message = "Create VpBank customer failed",
                    StatusCode = StatusCodes.Status400BadRequest
                };
        }
        catch (Exception e)
        {
            _logger.LogError("Create VpBank customer failed".GeneratedLog(ClassName, LogEventLevel.Error));
            _logger.LogError(e.Message);
            return new BaseResultApiResponse<CreateVpBankCustomerModel>()
            {
                Success = false,
                Message = "Create VpBank customer failed",
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    public async Task<BaseResultApiResponse<CreateLogEmailModel>> CreateEmailLog(CreateLogEmailModel emailLog)
    {
        try
        {
            _logger.LogInformation("Check Validate Email Log".GeneratedLog(ClassName, LogEventLevel.Information));
            var validate = new EmailLogValidator();
            var resultValidate = await validate.ValidateAsync(emailLog);
            if (resultValidate.Errors is { Count: > 0 })
                return new BaseResultApiResponse<CreateLogEmailModel>()
                {
                    Success = false,
                    Message = resultValidate.Errors.First().ErrorMessage,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            _logger.LogInformation("Create Email Log".GeneratedLog(ClassName, LogEventLevel.Information));
            var result = await _ofWork.VpBankRepository.CreateEmailLog(emailLog);
            return result
                ? new BaseResultApiResponse<CreateLogEmailModel>()
                {
                    Success = true,
                    Result = new[]
                    {
                        emailLog
                    },
                    Message = "Create Email Log successfully",
                    StatusCode = StatusCodes.Status200OK
                }
                : new BaseResultApiResponse<CreateLogEmailModel>()
                {
                    Success = false,
                    Message = "Create Email Log failed",
                    StatusCode = StatusCodes.Status400BadRequest
                };
        }
        catch (Exception e)
        {
            _logger.LogError("Create Email Log failed".GeneratedLog(ClassName, LogEventLevel.Error));
            _logger.LogError(e.Message);
            return new BaseResultApiResponse<CreateLogEmailModel>()
            {
                Success = false,
                Message = "Create Email Log failed",
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    public async Task<BaseResultApiResponse<dynamic>> GetLogEmailByIdVpBankCustomer(Guid id)
    {
        try
        {
            _logger.LogInformation(
                "Get Log Email By Id VpBank Customer".GeneratedLog(ClassName, LogEventLevel.Information));
            var result = await _ofWork.VpBankRepository.GetLogEmailByIdVpBankCustomer(id);
            return result.Any()
                ? new BaseResultApiResponse<dynamic>()
                {
                    Success = true,
                    Result = result,
                    Message = "Get Log Email By Id VpBank Customer successfully",
                    StatusCode = StatusCodes.Status200OK
                }
                : new BaseResultApiResponse<dynamic>()
                {
                    Success = false,
                    Result = null,
                    Message = "Get Log Email By Id VpBank Customer failed",
                    StatusCode = StatusCodes.Status404NotFound
                };
        }
        catch (Exception e)
        {
            _logger.LogError("Get Log Email By Id VpBank Customer failed".GeneratedLog(ClassName, LogEventLevel.Error));
            _logger.LogError(e.Message);
            return new BaseResultApiResponse<dynamic>()
            {
                Success = false,
                Result = null,
                Message = "Get Log Email By Id VpBank Customer failed",
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    public async Task<BaseResultApiResponse<bool>> DeleteVpBankCustomer(Guid id)
    {
        try
        {
            _logger.LogInformation("Delete VpBank Customer".GeneratedLog(ClassName, LogEventLevel.Information));
            var result = await _ofWork.VpBankRepository.DeleteVpBankCustomer(id);
            return result
                ? new BaseResultApiResponse<bool>()
                {
                    Success = true,
                    Message = "Delete VpBank Customer successfully",
                    StatusCode = StatusCodes.Status200OK
                }
                : new BaseResultApiResponse<bool>()
                {
                    Success = false,
                    Message = "Delete VpBank Customer failed",
                    StatusCode = StatusCodes.Status400BadRequest
                };
        }
        catch (Exception e)
        {
            _logger.LogError("Delete VpBank Customer failed".GeneratedLog(ClassName, LogEventLevel.Error));
            _logger.LogError(e.Message);
            return new BaseResultApiResponse<bool>()
            {
                Success = false,
                Message = "Delete VpBank Customer failed",
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    public async Task<BaseResultApiResponse<bool>> DeleteLogEmailByIdVpBankCustomer(Guid id)
    {
        try
        {
            _logger.LogInformation(
                "Delete Log Email By Id VpBank Customer".GeneratedLog(ClassName, LogEventLevel.Information));
            var result = await _ofWork.VpBankRepository.DeleteLogEmailByIdVpBankCustomer(id);
            return result
                ? new BaseResultApiResponse<bool>()
                {
                    Success = true,
                    Message = "Delete Log Email By Id VpBank Customer successfully",
                    StatusCode = StatusCodes.Status200OK
                }
                : new BaseResultApiResponse<bool>()
                {
                    Success = false,
                    Message = "Delete Log Email By Id VpBank Customer failed",
                    StatusCode = StatusCodes.Status400BadRequest
                };
        }
        catch (Exception e)
        {
            _logger.LogError(
                "Delete Log Email By Id VpBank Customer failed".GeneratedLog(ClassName, LogEventLevel.Error));
            _logger.LogError(e.Message);
            return new BaseResultApiResponse<bool>()
            {
                Success = false,
                Message = "Delete Log Email By Id VpBank Customer failed",
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}