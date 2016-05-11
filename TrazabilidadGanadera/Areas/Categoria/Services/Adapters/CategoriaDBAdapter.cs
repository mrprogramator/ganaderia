using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Areas.Categoria.Services.Adapters
{
    public class CategoriaDBAdapter
    {
        private Data.DBContext context;

        public CategoriaDBAdapter(Data.DBContext context)
        {
            this.context = context;
        }

        public CategoriaDBAdapter()
        {
            this.context = new Data.DBContext();
        }

        public IEnumerable<Entities.Categoria> Categorias
        {
            get
            {
                return context.Categorias.ToArray();
            }
        }

        public Entities.Categoria GetById(Object id)
        {
            return context.Categorias.Find(id);
        }

        public Entities.Categoria Insert(Entities.Categoria entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity = context.Categorias.Add(entity);

            context.SaveChanges();

            return entity;
        }

        public Entities.Categoria Update(Entities.Categoria entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            context.SaveChanges();

            return entity;
        }

        public Entities.Categoria Remove(Entities.Categoria entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            context.Categorias.Remove(entity);

            context.SaveChanges();

            return entity;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}