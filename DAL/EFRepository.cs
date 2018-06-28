using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL
{
    public class EFRepository : IRepository
    {
        DbContext _context;

        public EFRepository(DbContext context)
        {
            _context = context;
        }

        public TEntity Create<TEntity>(TEntity toCreate) where TEntity : class
        {
            TEntity result = default(TEntity);

            try
            {
                _context.Set<TEntity>().Add(toCreate);
                _context.SaveChanges();
                result = toCreate;
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public bool Delete<TEntity>(TEntity toDelete) where TEntity : class
        {
            bool result = false;

            try
            {
                _context.Entry<TEntity>(toDelete).State = EntityState.Deleted;
                result = _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            TEntity result = null;

            try
            {
                result =  _context.Set<TEntity>().FirstOrDefault(criteria);
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public List<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            List<TEntity> result = null;

            try
            {
                result =  _context.Set<TEntity>().Where(criteria).ToList();
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public bool Update<TEntity>(TEntity toUpdate) where TEntity : class
        {
            bool result = false;

            try
            {
                _context.Entry<TEntity>(toUpdate).State = EntityState.Modified;
                result = _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
            }

            return result;
        }
    }
}
