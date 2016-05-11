using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Areas.Bovino.Domain
{
    public class Bovino
    {
        public String Id { get; set; }

        public String Nombre { get; set; }

        public Bovino Madre { get; set; }

        public Bovino Padre { get; set; }

        public Areas.Categoria.Domain.Categoria Categoria { get; set; }

        public Domain.Bovino CargarPadre(String padreId)
        {
            if (padreId == null)
            {
                return null;
            }

            var padre = Services.Lists.BovinoList.GetInstance().GetById(padreId);

            if (padre == null)
            {
                return null;
            }

            this.Padre = new Domain.Bovino() 
            {
                Id = padre.Id,
                Nombre = padre.Nombre
            };

            return this.Padre;
        }

        public Domain.Bovino CargarMadre(String madreId)
        {
            if (madreId == null)
            {
                return null;
            }
            
            var madre = Services.Lists.BovinoList.GetInstance().GetById(madreId);

            if (madre == null)
            {
                return null;
            }

            this.Madre = new Domain.Bovino()
            {
                Id = madre.Id,
                Nombre = madre.Nombre,
            };

            return this.Madre;
        }

        public Areas.Categoria.Domain.Categoria CargarCategoria(Areas.Categoria.Entities.Categoria categoria)
        {
            if (categoria == null)
            {
                return null;
            }

            this.Categoria = new Areas.Categoria.Domain.Categoria()
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                Sexo = categoria.Sexo
            };

            return this.Categoria;
        }
    }
}