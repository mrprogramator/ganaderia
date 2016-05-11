using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Areas.Bovino.Entities
{
    [Table("bovino")]
    public class Bovino
    {
        [Key]
        [Column("id")]
        public String Id { get; set; }

        [Column("nombre")]
        public String Nombre { get; set; }

        [Column("padre_id", Order= 0)]
        public String PadreId { get; set; }

        [Column("madre_id", Order = 1)]
        public String MadreId { get; set; }

        [ForeignKey("Categoria")]
        [Column("categoria_id", Order = 2)]
        public String CategoriaId { get; set; }


        public virtual Areas.Categoria.Entities.Categoria Categoria { get; set; }
    }
}