using CashFlow.Communication.Request;
using CashFlow.Communication.Response;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionsBase;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpensesUseCase : IRegisterExpensesUseCase
{
    private readonly IExpensesRepository _repository;

    public RegisterExpensesUseCase(IExpensesRepository repository)
    {
        _repository = repository;
    }

    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            Title = request.Title,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
        };
        _repository.Add(entity);

        return new ResponseRegisterExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
