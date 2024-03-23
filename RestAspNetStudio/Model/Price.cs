
using RestAspNetStudio.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNet8VStudio.Model
{
    [Table("prices")]
    public class Price : BaseEntity
    {
        [Column("room_id")]
        public long? RoomId { get; set; }
        [Column("start_date")]
        public DateTime? StartDate { get; set; }
        [Column("end_date")]
        public DateTime? EndDate { get; set; }
        [Column("amount")]
        public decimal? Amount { get; set; }
        [Column("currency")]
        public string? Currency { get; set; }
    }
}
