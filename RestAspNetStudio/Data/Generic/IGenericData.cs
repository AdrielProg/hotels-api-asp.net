using RestAspNetStudio.Model.Base;

namespace RestAspNetStudio.Data.Generic
{
    public interface IGenericData<T> where T : BaseEntity
    {
        List<T> FindAll();
        T FindById(long id);
        T Create(T item);
        T Update(T item);
        void Delete(long id);   
    }
    
    }

