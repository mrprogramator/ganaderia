using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrazabilidadGanadera.Areas.Categoria.Controllers
{
    public class CategoriaController : Controller
    {
        private Services.Lists.CategoriaList list;
        private TrazabilidadGanadera.Services.ListService listService;

        public CategoriaController()
        {
            list = Services.Lists.CategoriaList.GetInstance();
            listService = new TrazabilidadGanadera.Services.ListService();
        }

        public ActionResult Index()
        {
            var model = list.Select(item => new Models.Categoria()
            {
                Id = item.Id,
                Nombre = item.Nombre,
                Descripcion = item.Descripcion
            });
            
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new Models.Categoria());
        }

        [HttpPost]
        public ActionResult Create(Models.Categoria model)
        {
            try
            {
                var categoriaDomain = new Domain.Categoria()
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                    Sexo = model.SexoId
                };
                
                list.Add(categoriaDomain);

                return Redirect("/categoria/categoria");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("ERROR", e.ToString());
                
                return View(model);
            }
        }

        public ActionResult Edit(String id)
        {
            var categoriaDomain = list.GetById(id);

            var model = new Models.Categoria();

            if (categoriaDomain == null)
            {
                ModelState.AddModelError("ERROR", "No se encuentra la categoría " + id);
            }
            else
            {
                model.Id = categoriaDomain.Id;
                model.Nombre = categoriaDomain.Nombre;
                model.Descripcion = categoriaDomain.Descripcion;
                model.SexoId = categoriaDomain.Sexo;

                var sexo = model.Sexos.Where(s => s.Value.Equals(model.SexoId)).FirstOrDefault();

                if (sexo == null)
                {
                    ModelState.AddModelError("ERROR", "No se encuentra el sexo " + model.SexoId);
                }
                else
                {
                    model.SexoNombre = sexo.Text;
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.Categoria model)
        {
            try
            {
                var categoriaDomain = list.GetById(model.Id);

                categoriaDomain.Nombre = model.Nombre;
                categoriaDomain.Descripcion = model.Descripcion;
                categoriaDomain.Sexo = model.SexoId;

                list.Edit(categoriaDomain);

                return Redirect("/categoria/categoria");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("ERROR", e.ToString());

                return View(model);
            }
        }

        public ActionResult Delete(String id)
        {
            var categoriaDomain = list.GetById(id);
            
            var model = new Models.Categoria();

            if (categoriaDomain == null)
            {
                ModelState.AddModelError("ERROR", "No se encuentra la categoría " + id);
            }
            else
            {
                model.Id = categoriaDomain.Id;
                model.Nombre = categoriaDomain.Nombre;
                model.Descripcion = categoriaDomain.Descripcion;
                model.SexoId = categoriaDomain.Sexo;

                var sexo = model.Sexos.Where(s => s.Value.Equals(model.SexoId)).FirstOrDefault();

                if (sexo == null)
                {
                    ModelState.AddModelError("ERROR", "No se encuentra el sexo " + model.SexoId);
                }
                else
                {
                    model.SexoNombre = sexo.Text;
                }
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Models.Categoria model)
        {
            try
            {
                var categoriaDomain = list.GetById(model.Id);

                if (categoriaDomain == null)
                {
                    throw new Exception("No se encuentra la categoría");
                }

                var bovino = listService.GetBovinoList().Where(b => b.Categoria.Id.Equals(categoriaDomain.Id)).FirstOrDefault();

                if (bovino != null)
                {
                    throw new Exception("No se puede eliminar la categoría " + model.Nombre + " porque existen bovinos que pertenecen a esta categoría");
                }

                list.Remove(categoriaDomain);

                return Redirect("/categoria/categoria");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("ERROR", e.ToString());

                return View(model);
            }
        }

        public ActionResult Detail(String id)
        {
            var categoriaDomain = list.GetById(id);
            
            var model = new Models.Categoria();

            if (categoriaDomain == null)
            {
                ModelState.AddModelError("ERROR", "No se encuentra la categoría " + id);
            }
            else
            {
                model.Id = categoriaDomain.Id;
                model.Nombre = categoriaDomain.Nombre;
                model.Descripcion = categoriaDomain.Descripcion;
                model.SexoId = categoriaDomain.Sexo;

                var sexo = model.Sexos.Where(s => s.Value.Equals(model.SexoId)).FirstOrDefault();

                if (sexo == null)
                {
                    ModelState.AddModelError("ERROR", "No se encuentra el sexo " + model.SexoId);
                }
                else
                {
                    model.SexoNombre = sexo.Text;
                }
            }

            return View(model);
        }
    }
}
