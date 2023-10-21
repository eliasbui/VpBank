using Model.Request;

namespace Infrastructure.Repository.IRepository;

public interface IVpBankRepository
{
    Task<IReadOnlyList<dynamic>> GetAllVpBankCustomer();
    Task<bool> CreateVpBankCustomer(CreateVpBankCustomerModel vpBankCustomer);
    Task<bool> CreateEmailLog(CreateLogEmailModel emailLog);
    Task<IReadOnlyList<dynamic>> GetLogEmailByIdVpBankCustomer(Guid id);
    Task<bool> DeleteVpBankCustomer(Guid id);
    Task<bool> DeleteLogEmailByIdVpBankCustomer(Guid id);
}