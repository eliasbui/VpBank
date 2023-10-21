using Infrastructure.Contract;
using Infrastructure.Repository.IRepository;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IVpBankRepository VpBankRepository { get; }

    public UnitOfWork(IVpBankRepository vpBankRepository)
    {
        VpBankRepository = vpBankRepository;
    }
}