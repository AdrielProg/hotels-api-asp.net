
using System.ComponentModel.DataAnnotations.Schema;
using RestAspNetStudio.Model.Base;

namespace RestAspNetStudio.Model
{
    [Table("users")]
    public class User : BaseEntity  
    {

        [Column("first_name")]
        public string? FirstName { get; set; }
        [Column("last_name")]
        public string? LastName { get; set; }
        [Column("adress")]
        public string? Adress { get; set; }
        [Column("gender")]
        public string?  Gender { get; set; }

    }

}
