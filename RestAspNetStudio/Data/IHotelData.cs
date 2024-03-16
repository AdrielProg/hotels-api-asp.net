using RestAspNetStudio.Model;

namespace RestAspNetStudio.Data
{
    public interface IHotelData
    {
        List<Hotel> FindAll();
        Hotel FindById(long id);
        Hotel Create(Hotel hotel);
        Hotel Update(Hotel hotel);
        void Delete(long id);
    }
}
