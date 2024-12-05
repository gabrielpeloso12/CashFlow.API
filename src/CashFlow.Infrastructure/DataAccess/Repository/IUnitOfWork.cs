namespace CashFlow.Infrastructure.DataAccess.Repository;

public interface IUnitOfWork
{
    Task Commit();
}
