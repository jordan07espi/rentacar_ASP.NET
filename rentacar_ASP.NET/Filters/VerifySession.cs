using rentacar_ASPNET.Controllers;
using rentacar_ASPNET.Models.ViewModels.Access;
using System.Web;
using System.Web.Mvc;

namespace rentacar_ASPNET.Filters
{
    public class VerifySession:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (User)HttpContext.Current.Session["User"];
            if(oUser ==null)
            {
                if (filterContext.Controller is AccessController ==  false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
                
            }
            else if(oUser.RolId == 1)
            {
                if (filterContext.Controller is AccessController == true) {

                    filterContext.HttpContext.Response.Redirect("~/Home/Contact");
                }

               
            }
            else if (oUser.RolId == 2)
            {
                if (filterContext.Controller is AccessController == true)
                {

                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }


            }



            base.OnActionExecuting(filterContext);
        }
    }
}