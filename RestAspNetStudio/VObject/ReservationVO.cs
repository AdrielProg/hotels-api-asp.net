
namespace RestAspNet8VStudio.VObject
{

    public class ReservationVO
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? RoomId { get; set; }
        public DateTime? CheckinDateTime { get; set; }
        public DateTime? CheckoutDateTime { get; set; }

    }
}
