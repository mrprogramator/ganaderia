using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrazabilidadGanadera.Areas.Bovino.Services.Adapters
{
    public class BovinoDBAdapter
    {
        private Data.DBContext context;

        public BovinoDBAdapter(Data.DBContext context)
        {
            this.context = context;
        }

        public BovinoDBAdapter()
        {
            this.context = new Data.DBContext();
        }

        public IEnumerable<Entities.Bovino> Bovinos
        {
            get
            {
                return context.Bovinos.ToArray();
            }
        }

        public Entities.Bovino GetById(Object id)
        {
            return context.Bovinos.Find(id);
        }

        public Entities.Bovino Insert(Entities.Bovino entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entity = context.Bovinos.Add(entity);

            context.SaveChanges();

            return entity;
        }

        public Entities.Bovino Update(Entities.Bovino entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            context.SaveChanges();

            return entity;
        }

        public Entities.Bovino Remove(Entities.Bovino entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            context.Bovinos.Remove(entity);

            context.SaveChanges();

            return entity;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}