using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.Web.Framework.Mvc.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public ValidationFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        foreach (var (_, value) in context.ActionArguments)
        {
            if (value is null)
                continue;

            var result = await ValidateAsync(value);
            if (result?.IsValid != false)
                continue;

            context.Result = new BadRequestResult();
            return;
        }

        await next();
    }

    private async Task<ValidationResult?> ValidateAsync(object value)
    {
        var validator = GetValidator(value.GetType());
        if (validator == null)
            return null;

        var context = new ValidationContext<object>(value);
        return await validator.ValidateAsync(context);
    }

    private IValidator? GetValidator(Type targetType)
    {
        var validatorType = typeof(IValidator<>).MakeGenericType(targetType);
        var validator = (IValidator?)_serviceProvider.GetService(validatorType);
        return validator;
    }
}