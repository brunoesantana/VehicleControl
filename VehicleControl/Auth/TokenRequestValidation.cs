using Microsoft.AspNetCore.Mvc.Filters;

namespace VehicleControl.Auth
{
    public class TokenRequestValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            UserManagement.Validate(context.HttpContext.Request);
            base.OnActionExecuting(context);
        }
    }
}
