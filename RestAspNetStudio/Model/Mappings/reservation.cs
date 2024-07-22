using Dapper.FluentMap.Mapping;
using RestAspNet8VStudio.Model;

namespace RestAspNet8VStudio.Model.Mappings
{
    public class ReservationMap : EntityMap<Reservation>
    {
        public ReservationMap()
        {
            Map(r => r.UserId).ToColumn("user_id");
            Map(r => r.RoomId).ToColumn("room_id");
            Map(r => r.CheckinDateTime).ToColumn("checkin_date_time");
            Map(r => r.CheckoutDateTime).ToColumn("checkout_date_time");
        }
    }
}
