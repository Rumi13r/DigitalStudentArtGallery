using DigitalStudentArtGallery.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using DigitalStudentArtGallery.Extentions;

namespace DigitalStudentArtGallery.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<User>("loggedUser") == null)
            {
                string requestPath = context.HttpContext.Request.Path.Value;

                context.Result = new RedirectResult("/Home/Login?url=" + requestPath);
            }
        }
    }
}
