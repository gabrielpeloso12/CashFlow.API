using CashFlow.Communication.Request;
using CashFlow.Communication.Response;

namespace CashFlow.Application.UseCases.Expenses.Register;

public interface IRegisterExpensesUseCase
{
    ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request);
}
