using Microsoft.EntityFrameworkCore;
using RestAspNetStudio.Model.Base;
using RestAspNetStudio.Model.Context;

namespace RestAspNetStudio.Data.Generic
{
    public class GenericDataImplementation<T> : IGenericData<T> where T : BaseEntity
    {       
        private MySQLContext _context;
        private DbSet<T> _dataSet;
        public GenericDataImplementation(MySQLContext context){ 
        
            _context = context;
            _dataSet = _context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
                _context.SaveChanges();
            } catch (Exception)
            {
                throw;
            }
            return item;
        }

        public void Delete(long id)
        {
            var result = _dataSet.SingleOrDefault(u => u.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<T> FindAll()
        {
         return _dataSet.ToList();
        }


        public T FindById(long id)
        {
            //returno do SingleOrDefault é o proprio objeto
            return _dataSet.SingleOrDefault(u => u.Id.Equals(id));
            
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;
            var result =_dataSet.SingleOrDefault(u => u.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return item;
        }

        private bool Exists(long id)
        {
            //retono do Any é um boolean 
            return _dataSet.Any(u => u.Id.Equals(id));
        }
    }
}
