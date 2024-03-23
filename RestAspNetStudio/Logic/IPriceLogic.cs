using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Logic
{
    public interface IPriceLogic
    {
        List<PriceVO> FindAll();
        PriceVO FindById(long id);
        PriceVO Create(PriceVO price);
        PriceVO Update(PriceVO price);
        void Delete(long id);
    }
}
