using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Areas.Categoria.Domain
{
    public class Categoria
    {
        public String Id { get; set; }

        public String Nombre { get; set; }

        public String Descripcion { get; set; }

        public String Sexo { get; set; }
    }
}