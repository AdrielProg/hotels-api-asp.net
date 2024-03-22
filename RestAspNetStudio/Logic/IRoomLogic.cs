using RestAspNetStudio.Model;

namespace RestAspNetStudio.Logic
{
    public interface IRoomLogic
    {
        List<RoomVO> FindAll();
        RoomVO FindById(long id);
        RoomVO Create(RoomVO room);
        RoomVO Update(RoomVO room);
        void Delete(long id);
        public List<RoomVO> FindRoomsByHotelId(long hotelId);
    }
}

