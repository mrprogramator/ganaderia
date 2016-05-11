using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Data
{
    public class DBContext : DbContext
    {
        public DBContext()
            :base("DBConnection")
        {
        }

        public DbSet<Areas.Categoria.Entities.Categoria> Categorias { get; set; }

        public DbSet<Areas.Bovino.Entities.Bovino> Bovinos { get; set; }
    }
}