using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrazabilidadGanadera.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save()
        {
            return View(new Models.SaveChanges("¿Está seguro que desea guardar los cambios?"));
        }

        [HttpPost]
        public ActionResult SaveChanges()
        {
            try
            {
                var listAdapter = new Services.ListService();
                listAdapter.SaveChanges();

                return View(new Models.SaveChanges("Los cambios han sido guardados."));
            }
            catch (Exception e)
            {
                return View("SaveChangesError", new Models.SaveChanges("Error al guardar cambios. " + e.ToString()));
            }
        }
    }
}
