using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Services
{
    public class ListService
    {
        public void SaveChanges()
        {
            GetCategoriaList().SaveChanges();
            GetBovinoList().SaveChanges();
        }

        public Areas.Categoria.Services.Lists.CategoriaList GetCategoriaList()
        {
            return Areas.Categoria.Services.Lists.CategoriaList.GetInstance();
        }

        public Areas.Bovino.Services.Lists.BovinoList GetBovinoList()
        {
            return Areas.Bovino.Services.Lists.BovinoList.GetInstance();
        }
    }
}