
using System.ComponentModel.DataAnnotations.Schema;
using RestAspNetStudio.Model.Base;

namespace RestAspNetStudio.Model
{
    [Table("rooms")]
    public class Room : BaseEntity
    {

        [Column("hotel_id")]
        public long HotelId { get; set; }
        [Column("room_number")]
        public string? RoomNumber{ get; set; }
        [Column("capacity")]
        public int? Capacity{ get; set; }
        [Column("description")]
        public string?  Description{ get; set; }
        [Column("photos")]
        public string? Photos{ get; set; }


    }

}
