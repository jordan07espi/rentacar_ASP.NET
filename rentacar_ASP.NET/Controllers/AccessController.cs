using Microsoft.Ajax.Utilities;
using rentacar_ASP.NET.Models;
using rentacar_ASPNET.Models.ViewModels.Access;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
            string resp = "Usuario o clave no son válidas";
            try
            {
                User loggedUser = new User();
                
                using (rentacarEntities db = new rentacarEntities())
                {
                    loggedUser = (from u in db.usuarios
                          where u.nombreUsuario == user &&
                          u.contraseña == pass && u.estado == 1
                          select new User()
                          {
                              Id= u.id,
                              Name=u.nombreUsuario
                          }).First();
  
                }

                if(loggedUser != null)
                {
                    Session["User"] = loggedUser;
                    resp = "1";

                }




                return Content(resp);
                
            }catch(Exception ex)
            {
                return Content(ex.Message);
            }
            

        }
    }
}