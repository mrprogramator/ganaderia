using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Areas.Categoria.Entities
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
        [Column("id")]
        public String Id { get; set; }

        [Column("nombre")]
        public String Nombre { get; set; }

        [Column("descripcion")]
        public String Descripcion { get; set; }

        [Column("sexo")]
        public String Sexo { get; set; }
    }
}