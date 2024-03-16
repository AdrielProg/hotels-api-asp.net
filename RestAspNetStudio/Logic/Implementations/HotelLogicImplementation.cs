using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestAspNetStudio.Data;
using RestAspNetStudio.Model;
using RestAspNetStudio.Model.Context;

namespace RestAspNetStudio.Logic.Implementations
{
    public class HotelLogicImplementation : IHotelLogic
    {       
       private readonly IHotelData _data;

        public HotelLogicImplementation(IHotelData data){ _data = data;}
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
