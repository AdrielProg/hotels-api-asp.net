using RestAspNetStudio.Model;

namespace RestAspNetStudio.Logic
{
    public interface IHotelLogic
    {
        List<HotelVO> FindAll();
        HotelVO FindById(long id);
        HotelVO Create(HotelVO hotel);
        HotelVO Update(HotelVO hotel);
        void Delete(long id);
       
    }
}
