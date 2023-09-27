using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tasks.ActionFilters
{
    public class ExceptionsHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is not null)
            {
                context.ExceptionHandled = true;
                context.Result = new ViewResult() { ViewName = "Errorring" };
            }
            base.OnActionExecuted(context);
        }
    }
}
