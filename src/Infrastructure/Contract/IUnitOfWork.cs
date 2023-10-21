using Infrastructure.Repository.IRepository;

namespace Infrastructure.Contract;

public interface IUnitOfWork
{
    IVpBankRepository VpBankRepository { get; }
}