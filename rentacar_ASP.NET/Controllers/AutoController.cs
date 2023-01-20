using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using rentacar_ASP.NET.Models;
using rentacar_ASPNET.Models;
using rentacar_ASPNET.Models.ViewModels;

namespace entacar_ASPNET.Controllers
{
    public class AutoController : Controller
    {
        // GET: Auto
        public ActionResult Index()
        {
            List<ListAutoViewModel> lst;

            using (rentacarEntities db = new rentacarEntities())
            {
                lst = (from d in db.auto
                       select new ListAutoViewModel
                       {

                           idauto = d.idauto,
                           marca = d.marca,

                           placa = d.placa,
                           tipo = d.tipo,
                           estado = d.estado,
                           estadoAlquiler = d.estadoAlquiler,


                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(AutoViewModel automodel)
        {
            try
            {
                HttpPostedFileBase FileBase = Request.Files[0];
                WebImage imagen = new WebImage(FileBase.InputStream);
                automodel.fotoAuto = imagen.GetBytes();
                //Validar los datos Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido, vamos a guardar los datos en la base
                    using (rentacarEntities db = new rentacarEntities())
                    {
                        var oAuto = new auto();
                        oAuto.idauto = automodel.idauto;
                        oAuto.marca = automodel.marca;
                        oAuto.placa = automodel.placa;
                        oAuto.tipo = automodel.tipo;
                        oAuto.estado = automodel.estado;
                        oAuto.estadoAlquiler = 0;
                        oAuto.fotoAuto = automodel.fotoAuto;



                        db.auto.Add(oAuto);
                        db.SaveChanges();

                    }
                    return Redirect("~/Auto/Index");

                }
                return View(automodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public ActionResult Editar(int id)
        {
            AutoViewModel model = new AutoViewModel();
            using (rentacarEntities db = new rentacarEntities())
            {
                var oAuto = db.auto.Find(id);
                model.idauto= oAuto.idauto ;
                model.marca =  oAuto.marca;
                model.placa=  oAuto.placa;
                model.tipo = oAuto.tipo;
                model.estado= oAuto.estado;
                model.estadoAlquiler = oAuto.estadoAlquiler;
                model.fotoAuto = oAuto.fotoAuto;


            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(AutoViewModel automodel)
        {
            try
            {
                HttpPostedFileBase FileBase = Request.Files[0];
                WebImage imagen = new WebImage(FileBase.InputStream);
                automodel.fotoAuto = imagen.GetBytes();
                //Validar los datos Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido, vamos a guardar los datos en la base
                    using (rentacarEntities db = new rentacarEntities())
                    {
                        var oAuto = new auto();
                        oAuto.idauto = automodel.idauto;
                        oAuto.marca = automodel.marca;
                        oAuto.placa = automodel.placa;
                        oAuto.tipo = automodel.tipo;
                        oAuto.estado = automodel.estado;
                        oAuto.estadoAlquiler = (short)automodel.estadoAlquiler;
                        oAuto.fotoAuto = automodel.fotoAuto;



                        db.Entry(oAuto).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Auto/Index");

                }
                return View(automodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (rentacarEntities db = new rentacarEntities())
            {
                var oAuto = db.auto.Find(id);
                db.auto.Remove(oAuto);
                db.SaveChanges();
            }
            return Redirect("~/Auto/");
        }


        public ActionResult MostrarImagen(int id)
        {

            rentacarEntities db = new rentacarEntities();

            auto model = db.auto.Find(id);
            byte[] byteImage = model.fotoAuto;
            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image imagen = Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            imagen.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
        }







    }
}