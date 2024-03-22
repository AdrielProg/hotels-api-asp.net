
using Microsoft.EntityFrameworkCore;
using RestAspNetStudio.Data.Generic;
using RestAspNetStudio.Model;
using RestAspNetStudio.VObject.Converter.Implementations;

namespace RestAspNetStudio.Logic.Implementations
{
    public class RoomLogicImplementation : IRoomLogic
    {       
       private readonly IGenericData<Room> _data;
        private readonly RoomConverter _converter;

        public RoomLogicImplementation(IGenericData<Room> data)
        {
            _data = data;
            _converter = new RoomConverter();
        }
        public RoomVO Create(RoomVO room)
        {
            var roomEntity = _converter.Convert(room);
            roomEntity = _data.Create(roomEntity);
            return _converter.Convert(roomEntity);      
        }

        public void Delete(long id)
        {
           _data.Delete(id);
        }

        public List<RoomVO> FindAll()
        {
         return _converter.Convert(_data.FindAll()).ToList();
        }

        public RoomVO FindById(long id)
        { 
            return _converter.Convert(_data.FindById(id));   
        }

        public RoomVO Update(RoomVO room)
        {

            var roomEntity = _converter.Convert(room);
            roomEntity = _data.Update(roomEntity);
            return _converter.Convert(roomEntity);
        }

        public List<RoomVO> FindRoomsByHotelId(long hotelId)
        {
            var roomEntity = _data.FindAll().Where(room => room.HotelId == hotelId).ToList();
            return _converter.Convert(roomEntity);
        }

    }
}
