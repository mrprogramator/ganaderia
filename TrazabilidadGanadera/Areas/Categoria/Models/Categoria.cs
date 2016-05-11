using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrazabilidadGanadera.Areas.Categoria.Models
{
    public class Categoria
    {
        public String Id { get; set; }

        public String Nombre { get; set; }

        public String Descripcion { get; set; }

        public String SexoId { get; set; }

        public String SexoNombre { get; set; }

        public IEnumerable<SelectListItem> Sexos {
            get 
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = "Hembra", Value = "FEM"},
                    new SelectListItem { Text = "Macho", Value = "MAS"}
                };
            }
        }
    }
}