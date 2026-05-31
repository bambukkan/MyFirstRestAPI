using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyLibrary.API.Filters;

public class FilterValidation : IActionFilter
{
    private readonly ILogger<FilterValidation> _logger;

    public FilterValidation(ILogger<FilterValidation> logger)
    {
        _logger = logger;
    }
    //делается после контроллера
    public void OnActionExecuted(ActionExecutedContext context) {} 

    //делается перед контроллером
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            _logger.LogError("Model state is not valid");
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}