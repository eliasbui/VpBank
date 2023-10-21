using Common.Base;
using Model.Request;

namespace Application.Service.IService;

public interface IVpBankService
{
    Task<BaseResultApiResponse<dynamic>> GetAllVpBankCustomer();
    Task<BaseResultApiResponse<CreateVpBankCustomerModel>> CreateVpBankCustomer(CreateVpBankCustomerModel vpBankCustomer);
    Task<BaseResultApiResponse<CreateLogEmailModel>> CreateEmailLog(CreateLogEmailModel emailLog);
    Task<BaseResultApiResponse<dynamic>> GetLogEmailByIdVpBankCustomer(Guid id);
    Task<BaseResultApiResponse<bool>> DeleteVpBankCustomer(Guid id);
    Task<BaseResultApiResponse<bool>> DeleteLogEmailByIdVpBankCustomer(Guid id);
}