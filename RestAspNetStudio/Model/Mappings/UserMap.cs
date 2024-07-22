using Dapper.FluentMap.Mapping;

namespace RestAspNetStudio.Model.Mappings
{
    public class UserMap : EntityMap<User>
    {
        public UserMap()
        {
            Map(u => u.FirstName).ToColumn("first_name");
            Map(u => u.LastName).ToColumn("last_name");
            Map(u => u.Adress).ToColumn("adress");
            Map(u => u.Gender).ToColumn("gender");
        }
    }
}
