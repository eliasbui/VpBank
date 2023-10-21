using Dapper;
using Infrastructure.Context;
using Infrastructure.Queries;
using Infrastructure.Repository.IRepository;
using Model.Request;

namespace Infrastructure.Repository;

public class VpBankRepository : IVpBankRepository
{
    private readonly DataContext _dataContext;

    public VpBankRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IReadOnlyList<dynamic>> GetAllVpBankCustomer()
    {
        using var connection = _dataContext.CreateConnection();
        connection.Open();
        var result = await connection.QueryAsync<dynamic>(VpBankQueries.GetAllVpBankCustomers);
        return result.AsList();
    }

    public async Task<bool> CreateVpBankCustomer(CreateVpBankCustomerModel vpBankCustomer)
    {
        using var connection = _dataContext.CreateConnection();
        connection.Open();
        var result = await connection.ExecuteAsync(VpBankQueries.InsertVpBankCustomer, vpBankCustomer);
        return result > 0;
    }

    public async Task<bool> CreateEmailLog(CreateLogEmailModel emailLog)
    {
        using var connection = _dataContext.CreateConnection();
        connection.Open();
        var result = await connection.ExecuteAsync(VpBankQueries.InsertLogEmail, emailLog);
        return result > 0;
    }

    public async Task<IReadOnlyList<dynamic>> GetLogEmailByIdVpBankCustomer(Guid id)
    {
        using var connection = _dataContext.CreateConnection();
        connection.Open();
        var result = await connection.QueryAsync<dynamic>(VpBankQueries.GetLogEmailByIdCustomer, new { id });
        return result.AsList();
    }

    public async Task<bool> DeleteVpBankCustomer(Guid id)
    {
        using var connection = _dataContext.CreateConnection();
        connection.Open();
        var result = await connection.ExecuteAsync(VpBankQueries.DeleteVpBankCustomer, new { id });
        return result > 0;
    }

    public async Task<bool> DeleteLogEmailByIdVpBankCustomer(Guid id)
    {
        using var connection = _dataContext.CreateConnection();
        connection.Open();
        var result = await connection.ExecuteAsync(VpBankQueries.DeleteLogEmailByIdCustomer, new { id });
        return result > 0;
    }
}