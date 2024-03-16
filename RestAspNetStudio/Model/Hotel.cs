
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAspNetStudio.Model
{
    [Table("hotels")]
    public class Hotel
    {
        [Column("id")]
        public  long Id  { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("adress")]
        public string? Adress{ get; set; }
        [Column("phone")]
        public string? Phone{ get; set; }
        [Column("description")]
        public string?  Description{ get; set; }
        [Column("rating")]
        public int? Rating { get; set; }


    }

}
