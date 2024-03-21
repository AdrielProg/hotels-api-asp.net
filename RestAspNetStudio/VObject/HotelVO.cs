
using System.ComponentModel.DataAnnotations.Schema;
using RestAspNetStudio.Model.Base;

namespace RestAspNetStudio.Model
{
    
    public class HotelVO 
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Adress{ get; set; }
        public string? Phone{ get; set; }  
        public string?  Description{ get; set; }
        public int? Rating { get; set; }


    }

}
