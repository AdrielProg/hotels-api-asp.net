using Dapper.FluentMap.Mapping;
using RestAspNetStudio.Model;

namespace RestAspNetStudio.Model.Mappings
{
    public class HotelMap : EntityMap<Hotel>
    {
        public HotelMap()
        {
            Map(h => h.Name).ToColumn("name");
            Map(h => h.Adress).ToColumn("adress");
            Map(h => h.Phone).ToColumn("phone");
            Map(h => h.Description).ToColumn("description");
            Map(h => h.Rating).ToColumn("rating");
        }
    }
}
