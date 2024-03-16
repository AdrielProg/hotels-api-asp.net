using RestAspNetStudio.Model;

namespace RestAspNetStudio.Logic
{
    public interface IHotelLogic
    {
        List<Hotel> FindAll();
        Hotel FindById(long id);
        Hotel Create(Hotel hotel);
        Hotel Update(Hotel hotel);
        void Delete(long id);
    }
}
