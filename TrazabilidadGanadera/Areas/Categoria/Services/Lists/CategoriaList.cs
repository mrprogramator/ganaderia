using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Areas.Categoria.Services.Lists
{
    public class CategoriaList : List<Domain.Categoria>
    {
        private static CategoriaList instance;

        private CategoriaList()
        {
            
        }

        public static CategoriaList GetInstance()
        {
            if (instance == null)
            {
                var dbAdapter = new Adapters.CategoriaDBAdapter();

                var items = dbAdapter
                    .Categorias
                    .Select(item => new Domain.Categoria()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        Sexo = item.Sexo
                    }).ToList();

                instance = new CategoriaList();
                instance.AddRange(items);

                dbAdapter.Dispose();
            }

            return instance;
        }

        public Domain.Categoria GetById(String id)
        {
            return instance.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public Domain.Categoria Edit(Domain.Categoria domain)
        {
            var item = GetById(domain.Id);

            item.Nombre = domain.Nombre;
            item.Descripcion = domain.Descripcion;
            item.Sexo = domain.Sexo;

            return item;
        }

        public void SaveChanges()
        {
            var dbAdapter = new Adapters.CategoriaDBAdapter();

            foreach (var item in instance)
            {
                var entity = dbAdapter.GetById(item.Id);

                if (entity == null)
                {
                    entity = new Entities.Categoria()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        Sexo = item.Sexo
                    };

                    dbAdapter.Insert(entity);
                }
                else
                {
                    entity.Nombre = item.Nombre;
                    entity.Descripcion = item.Descripcion;
                    entity.Sexo = item.Sexo;

                    dbAdapter.Update(entity);
                }
            }

            var entites = dbAdapter.Categorias.ToArray();

            foreach (var entity in entites)
            {
                var domain = instance.GetById(entity.Id);

                if (domain == null)
                {
                    dbAdapter.Remove(entity);
                }
            }

            dbAdapter.Dispose();
        }
    }
}