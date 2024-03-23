
namespace RestAspNet8VStudio.VObject
{

    public class PriceVO
    {
        public long Id { get; set; }
        public long? RoomId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
    }
}
