using Microsoft.AspNetCore.Mvc.Filters;

namespace AndradeProducts.API.Tools.ExceptionHandler
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool invalidModelState = !context.ModelState.IsValid;

            if (invalidModelState)
            {
                context.Result = new ModelStateValidationFailedResult(context.ModelState);
            }
        }
    }
}
