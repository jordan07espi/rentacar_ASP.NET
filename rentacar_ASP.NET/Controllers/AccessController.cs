using rentacar_ASPNET.Models.ViewModels.Access;
using System;
using System.Linq;
using System.Web.Mvc;
using rentacar_ASP.NET.Models;

namespace rentacar_ASPNET.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Enter(string user, string pass)
        {
            string resp = "";
            try
            {
                User loggedUser = new User();
                
                using (rentacarEntities db = new rentacarEntities())
                {
                    loggedUser = (from u in db.usuarios join rolu in db.rolesusuarios
                                  on u.id equals rolu.idUsuario
                                  where u.nombreUsuario == user &&
                          u.contraseña == pass && u.estado == 1
                          select new User()
                          {
                              Id    =   u.id,
                              Name  =   u.nombreUsuario,
                              RolId =   rolu.idRol
                          }).First();
  
                }

                Session["User"] = loggedUser;
                if (loggedUser != null && loggedUser.RolId==1)
                {
                    resp = "1";

                }
                else if(loggedUser != null && loggedUser.RolId == 2)
                {
                    resp = "2";
                }
                else
                {
                    resp = "Usuario o clave no son válidos";
                }




                return Content(resp);
                
            }catch(Exception)
            {
                return Content("No se pudo establecer conexión con el servidor");
            }
            

        }
    }
}