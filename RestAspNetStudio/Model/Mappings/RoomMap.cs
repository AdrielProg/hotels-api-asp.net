using Dapper.FluentMap.Mapping;
using RestAspNetStudio.Model;

namespace RestAspNetStudio.Model.Mappings
{
    public class RoomMap : EntityMap<Room>
    {
        public RoomMap()
        {
            Map(r => r.HotelId).ToColumn("hotel_id");
            Map(r => r.RoomNumber).ToColumn("room_number");
            Map(r => r.Capacity).ToColumn("capacity");
            Map(r => r.Description).ToColumn("description");
            Map(r => r.Photos).ToColumn("photos");
        }
    }
}
