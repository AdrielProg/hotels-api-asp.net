using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestAspNetStudio.Data.Generic;
using RestAspNetStudio.Data;
using RestAspNetStudio.Model;
using RestAspNetStudio.Model.Context;

namespace RestAspNetStudio.Logic.Implementations
{
    public class HotelLogicImplementation : IHotelLogic
    {       
       private readonly IGenericData<Hotel> _data;

        public HotelLogicImplementation(IGenericData<Hotel> data){ _data = data;}
        public Hotel Create(Hotel hotel)
        {
            
            return _data.Create(hotel);
        }

        public void Delete(long id)
        {
           _data.Delete(id);
        }

        public List<Hotel> FindAll()
        {
         return _data.FindAll();
        }

        public Hotel FindById(long id)
        {
            //returno do SingleOrDefault é o proprio objeto
            return _data.FindById(id);   
        }

        public Hotel Update(Hotel hotel)
        {
            return _data.Update(hotel);
        }

    }
}
