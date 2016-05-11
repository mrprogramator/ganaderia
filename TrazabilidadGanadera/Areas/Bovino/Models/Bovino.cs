using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrazabilidadGanadera.Areas.Bovino.Models
{
    public class Bovino
    {
        public String Id { get; set; }

        public String Nombre { get; set; }

        public String PadreId { get; set; }

        public String PadreNombre { get; set; }

        public String MadreId { get; set; }

        public String MadreNombre { get; set; }

        public String CategoriaId { get; set; }

        public String CategoriaNombre { get; set; }

        public IEnumerable<SelectListItem> Madres
        {
            get
            {
                var list = Services
                    .Lists
                    .BovinoList
                    .GetInstance()
                    .Where(i => i.Categoria.Sexo.Equals("FEM"));

                var madres = new List<Domain.Bovino>(list);

                var bovino = madres.Where(m => m.Id.Equals(Id)).FirstOrDefault();

                if (bovino != null)
                {
                    madres.Remove(bovino);
                }

                var items = new List<SelectListItem>();

                foreach (var madre in madres)
                {
                    var item = new SelectListItem()
                    {
                        Value = madre.Id,
                    };

                    if (item.Value.Equals(MadreId))
                    {
                        item.Selected = true;
                    }

                    if (String.IsNullOrEmpty(madre.Nombre) || String.IsNullOrWhiteSpace(madre.Nombre))
                    {
                        item.Text = item.Value;
                    }
                    else
                    {
                        item.Text = madre.Nombre;
                    }

                    items.Add(item);
                }

                items.Add(new SelectListItem() { Value = "", Text = "Sin Madre" });
                return items;
            }
        }

        public IEnumerable<SelectListItem> Padres
        {
            get
            {
                var list = Services.Lists.BovinoList.GetInstance().Where(i => i.Categoria.Sexo.Equals("MAS"));
                var padres = new List<Domain.Bovino>(list);

                var bovino = padres.Where(m => m.Id.Equals(Id)).FirstOrDefault();

                if (bovino != null)
                {
                    padres.Remove(bovino);
                }

                var items = new List<SelectListItem>();

                foreach (var padre in padres)
                {
                    var item = new SelectListItem()
                    {
                        Value = padre.Id,
                    };

                    if (item.Value.Equals(PadreId))
                    {
                        item.Selected = true;
                    }

                    if (String.IsNullOrEmpty(padre.Nombre) || String.IsNullOrWhiteSpace(padre.Nombre))
                    {
                        item.Text = item.Value;
                    }
                    else
                    {
                        item.Text = padre.Nombre;
                    }

                    items.Add(item);
                }

                items.Add(new SelectListItem() { Value = "", Text = "Sin Padre" });

                return items;
            }
        }

        public IEnumerable<SelectListItem> Categorias
        {
            get
            {
                var items = Areas.Categoria
                    .Services.Lists.CategoriaList
                    .GetInstance()
                    .Select(item => new SelectListItem() 
                    {
                        Value = item.Id,
                        Text = item.Nombre
                    })
                    .ToArray();

                var currentCat = items.Where(i => i.Value.Equals(CategoriaId)).FirstOrDefault();

                if (currentCat != null)
                {
                    currentCat.Selected = true;
                }

                 return items;
            }
        }

    }
}