using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Areas.Bovino.Services.Lists
{
    public class BovinoList : List<Domain.Bovino>
    {
        private static BovinoList instance;

        private BovinoList()
        {

        }

        public static BovinoList GetInstance()
        {
            if (instance == null)
            {
                var dbAdapter = new Adapters.BovinoDBAdapter();

                var entities = dbAdapter
                    .Bovinos
                    .ToList();

                instance = new BovinoList();

                foreach (var entity in entities)
                {
                    var item = new Domain.Bovino();

                    item.Id = entity.Id;

                    item.Nombre = entity.Nombre;

                    item.Padre = item.CargarPadre(entity.PadreId);

                    item.Madre = item.CargarMadre(entity.MadreId);

                    item.Categoria = item.CargarCategoria(entity.Categoria);

                    instance.Add(item);
                }

                dbAdapter.Dispose();
            }

            return instance;
        }

        public Domain.Bovino GetById(String id)
        {
            return instance.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public Domain.Bovino Edit(Domain.Bovino domain)
        {
            var item = GetById(domain.Id);

            item.Nombre = domain.Nombre;
            item.Padre = domain.Padre;
            item.Madre = domain.Madre;
            item.Categoria = domain.Categoria;

            return item;
        }

        public void SaveChanges()
        {
            var dbAdapter = new Adapters.BovinoDBAdapter();

            foreach (var item in instance)
            {
                var entity = dbAdapter.GetById(item.Id);

                if (entity == null)
                {
                    entity = new Entities.Bovino();

                    entity.Id = item.Id;

                    entity.Nombre = item.Nombre;

                    if (item.Padre != null)
                    {
                        entity.PadreId = item.Padre.Id;
                    }

                    if (item.Madre != null)
                    {
                        entity.MadreId = item.Madre.Id;
                    }

                    if (item.Categoria != null)
                    {
                        entity.CategoriaId = item.Categoria.Id;
                    }

                    dbAdapter.Insert(entity);
                }
                else
                {
                    entity.Nombre = item.Nombre;

                    if (item.Padre != null)
                    {
                        entity.PadreId = item.Padre.Id;
                    }
                    else
                    {
                        entity.PadreId = "";
                    }

                    if (item.Madre != null)
                    {
                        entity.MadreId = item.Madre.Id;
                    }
                    else
                    {
                        entity.MadreId = "";
                    }

                    if (item.Categoria != null)
                    {
                        entity.CategoriaId = item.Categoria.Id;
                    }

                    dbAdapter.Update(entity);
                }
            }

            var entites = dbAdapter.Bovinos.ToArray();

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