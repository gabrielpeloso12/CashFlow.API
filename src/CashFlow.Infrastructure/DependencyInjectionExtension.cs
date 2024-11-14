using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext(services);
        AddRepository(services);
    }

    private static void AddRepository(IServiceCollection services)
    {
        services.AddScoped<IExpensesRepository, ExpensesRepository>();
    }

    private static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<CashFlowDbContext>();
    }
}
