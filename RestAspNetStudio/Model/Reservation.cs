
using RestAspNetStudio.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNet8VStudio.Model
{
    [Table("reservations")]
    public class Reservation : BaseEntity
    {
        [Column("user_id")]
        public long? UserId { get; set; }
        [Column("room_id")]
        public long? RoomId { get; set; }
        [Column("checkin_date_time")]
        public DateTime? CheckinDateTime { get; set; }
        [Column("checkout_date_time")]
        public DateTime? CheckoutDateTime { get; set; }

    }
}
