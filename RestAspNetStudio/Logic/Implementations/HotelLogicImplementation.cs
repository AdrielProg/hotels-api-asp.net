
using RestAspNetStudio.Data.Generic;
using RestAspNetStudio.Model;
using RestAspNetStudio.VObject.Converter.Implementations;

namespace RestAspNetStudio.Logic.Implementations
{
    public class HotelLogicImplementation : IHotelLogic
    {       
       private readonly IGenericData<Hotel> _data;
        private readonly HotelConverter _converter;

        public HotelLogicImplementation(IGenericData<Hotel> data)
        {
            _data = data;
            _converter = new HotelConverter();
        }
        public HotelVO Create(HotelVO hotel)
        {
            var hotelEntity = _converter.Convert(hotel);
            hotelEntity = _data.Create(hotelEntity);
            return _converter.Convert(hotelEntity);
            
        }

        public void Delete(long id)
        {
           _data.Delete(id);
        }

        public List<HotelVO> FindAll()
        {
         return _converter.Convert(_data.FindAll()).ToList();
        }

        public HotelVO FindById(long id)
        {
            //returno do SingleOrDefault é o proprio objeto
            return _converter.Convert(_data.FindById(id));   
        }

        public HotelVO Update(HotelVO hotel)
        {

            var hotelEntity = _converter.Convert(hotel);
            hotelEntity = _data.Update(hotelEntity);
            return _converter.Convert(hotelEntity);
        }

    }
}
