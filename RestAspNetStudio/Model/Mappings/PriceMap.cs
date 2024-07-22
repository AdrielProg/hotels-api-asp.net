using Dapper.FluentMap.Mapping;

namespace RestAspNet8VStudio.Model.Mappings
{
    public class PriceMap : EntityMap<Price>
    {
        public PriceMap()
        {
            Map(p => p.RoomId).ToColumn("room_id");
            Map(p => p.StartDate).ToColumn("start_date");
            Map(p => p.EndDate).ToColumn("end_date");
            Map(p => p.Amount).ToColumn("amount");
            Map(p => p.Currency).ToColumn("currency");
        }
    }
}
