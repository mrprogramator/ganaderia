using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrazabilidadGanadera.Areas.Bovino.Controllers
{
    public class BovinoController : Controller
    {
        private Services.Lists.BovinoList list;
        private TrazabilidadGanadera.Services.ListService listService;

        public BovinoController()
        {
            list = Services.Lists.BovinoList.GetInstance();
            listService = new TrazabilidadGanadera.Services.ListService();
        }

        public ActionResult Index()
        {
            var modelList = new List<Models.Bovino>();

            foreach (var item in list)
            {
                var model = new Models.Bovino()
                {
                    Id = item.Id,
                    Nombre = item.Nombre
                };

                if (item.Padre != null)
                {
                    model.PadreId = item.Padre.Id;
                    model.PadreNombre = item.Padre.Nombre;
                }

                if (item.Madre != null)
                {
                    model.MadreId = item.Madre.Id;
                    model.MadreNombre = item.Madre.Nombre;
                }

                if (item.Categoria != null)
                {
                    model.CategoriaId = item.Categoria.Id;
                    model.CategoriaNombre = item.Categoria.Nombre;
                }

                modelList.Add(model);
            }

            return View(modelList);
        }

        public ActionResult Create()
        {
            return View(new Models.Bovino());
        }

        [HttpPost]
        public ActionResult Create(Models.Bovino model)
        {
            try
            {
                var bovinoDomain = new Domain.Bovino()
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                };

                if (model.PadreId != null)
                {
                    bovinoDomain.Padre = list.GetById(model.PadreId);
                }
                else
                {
                    bovinoDomain.Padre = null;
                }

                if (model.MadreId != null)
                {
                    bovinoDomain.Madre = list.GetById(model.MadreId);
                }
                else
                {
                    bovinoDomain.Madre = null;
                }

                var categoria = listService
                    .GetCategoriaList()
                    .GetById(model.CategoriaId);

                if (categoria == null)
                {
                    throw new Exception("No se encuentra la categoría " + model.CategoriaId);
                }
                else
                {
                    bovinoDomain.Categoria = categoria;
                }

                list.Add(bovinoDomain);

                return Redirect("/bovino/bovino");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("ERROR", e.ToString());

                return View(model);
            }
        }

        public ActionResult Edit(String id)
        {
            var bovinoDomain = list.GetById(id);

            var model = new Models.Bovino();

            if (bovinoDomain == null)
            {
                ModelState.AddModelError("ERROR", "No se encuentra el bovino " + id);
            }
            else
            {
                model.Id = bovinoDomain.Id;
                model.Nombre = bovinoDomain.Nombre;

                if (bovinoDomain.Padre != null)
                {
                    model.PadreId = bovinoDomain.Padre.Id;
                    model.PadreNombre = bovinoDomain.Padre.Nombre;

                    if (String.IsNullOrEmpty(model.PadreNombre) || String.IsNullOrWhiteSpace(model.PadreNombre))
                    {
                        model.PadreNombre = model.PadreId.ToString();
                    }
                }

                if (bovinoDomain.Madre != null)
                {
                    model.MadreId = bovinoDomain.Madre.Id;
                    model.MadreNombre = bovinoDomain.Madre.Nombre;

                    if (String.IsNullOrEmpty(model.MadreNombre) || String.IsNullOrWhiteSpace(model.MadreNombre))
                    {
                        model.MadreNombre = model.MadreId.ToString();
                    }
                }

                if (bovinoDomain.Categoria != null)
                {
                    model.CategoriaId = bovinoDomain.Categoria.Id;
                    model.CategoriaNombre = bovinoDomain.Categoria.Nombre;
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.Bovino model)
        {
            try
            {
                var bovinoDomain = list.GetById(model.Id);

                bovinoDomain.Nombre = model.Nombre;
                
                if (model.PadreId != null)
                {
                    bovinoDomain.Padre = list.GetById(model.PadreId);
                }
                else
                {
                    bovinoDomain.Padre = null;
                }

                if (model.MadreId != null)
                {
                    bovinoDomain.Madre = list.GetById(model.MadreId);
                }
                else
                {
                    bovinoDomain.Madre = null;
                }

                var categoria = listService
                    .GetCategoriaList()
                    .GetById(model.CategoriaId);

                if (categoria == null)
                {
                    throw new Exception("No se encuentra la categoría " + model.CategoriaId);
                }
                else
                {
                    bovinoDomain.Categoria = categoria;
                }

                list.Edit(bovinoDomain);

                return Redirect("/bovino/bovino");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("ERROR", e.ToString());

                return View(model);
            }
        }

        public ActionResult Delete(String id)
        {
            var bovinoDomain = list.GetById(id);

            var model = new Models.Bovino();

            if (bovinoDomain == null)
            {
                ModelState.AddModelError("ERROR", "No se encuentra la categoría " + id);
            }
            else
            {
                model.Id = bovinoDomain.Id;
                model.Nombre = bovinoDomain.Nombre;
                
                if (bovinoDomain.Padre != null)
                {
                    model.PadreId = bovinoDomain.Padre.Id;
                    model.PadreNombre = bovinoDomain.Padre.Nombre;

                    if (String.IsNullOrEmpty(model.PadreNombre) || String.IsNullOrWhiteSpace(model.PadreNombre))
                    {
                        model.PadreNombre = model.PadreId.ToString();
                    }
                }

                if (bovinoDomain.Madre != null)
                {
                    model.MadreId = bovinoDomain.Madre.Id;
                    model.MadreNombre = bovinoDomain.Madre.Nombre;

                    if (String.IsNullOrEmpty(model.MadreNombre) || String.IsNullOrWhiteSpace(model.MadreNombre))
                    {
                        model.MadreNombre = model.MadreId.ToString();
                    }
                }

                if (bovinoDomain.Categoria != null)
                {
                    model.CategoriaId = bovinoDomain.Categoria.Id;
                    model.CategoriaNombre = bovinoDomain.Categoria.Nombre;
                }
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Models.Bovino model)
        {
            try
            {
                var bovinoDomain = list.GetById(model.Id);

                list.Remove(bovinoDomain);

                return Redirect("/bovino/bovino");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("ERROR", e.ToString());

                return View(model);
            }
        }

        public ActionResult Detail(String id)
        {
            var bovinoDomain = list.GetById(id);

            var model = new Models.Bovino();

            if (bovinoDomain == null)
            {
                ModelState.AddModelError("ERROR", "No se encuentra la categoría " + id);
            }
            else
            {
                model.Id = bovinoDomain.Id;
                model.Nombre = bovinoDomain.Nombre;
                
                if (bovinoDomain.Padre != null)
                {
                    model.PadreId = bovinoDomain.Padre.Id;
                    model.PadreNombre = bovinoDomain.Padre.Nombre;

                    if (String.IsNullOrEmpty(model.PadreNombre) || String.IsNullOrWhiteSpace(model.PadreNombre))
                    {
                        model.PadreNombre = model.PadreId.ToString();
                    }
                }

                if (bovinoDomain.Madre != null)
                {
                    model.MadreId = bovinoDomain.Madre.Id;
                    model.MadreNombre = bovinoDomain.Madre.Nombre;

                    if (String.IsNullOrEmpty(model.MadreNombre) || String.IsNullOrWhiteSpace(model.MadreNombre))
                    {
                        model.MadreNombre = model.MadreId.ToString();
                    }
                }

                if (bovinoDomain.Categoria != null)
                {
                    model.CategoriaId = bovinoDomain.Categoria.Id;
                    model.CategoriaNombre = bovinoDomain.Categoria.Nombre;
                }
            }

            return View(model);
        }

    }
}
