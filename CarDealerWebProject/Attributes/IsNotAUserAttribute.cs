using CarDealerWebProject.Core.Contracts;
using CarDealerWebProject.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarDealerWebProject.Attributes
{
    public class IsNotAUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ISellerService? userService = context.HttpContext.RequestServices.GetService<ISellerService>();

            if (userService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (userService != null && userService.ExistsByEmailAsync(context.HttpContext.User.Email()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

        }
    }
}
