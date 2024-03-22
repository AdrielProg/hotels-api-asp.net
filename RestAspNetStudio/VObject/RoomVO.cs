
using System.ComponentModel.DataAnnotations.Schema;
using RestAspNetStudio.Model.Base;

namespace RestAspNetStudio.Model
{
    
    public class RoomVO 
    {
        public long Id { get; set; }
        public long HotelId { get; set; }
        public string? RoomNumber { get; set; }
        public int? Capacity { get; set; }
        public string? Description { get; set; }  
        public string? Photos { get; set; }


    }

}
