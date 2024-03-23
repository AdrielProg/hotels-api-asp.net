using RestAspNet8VStudio.VObject;

namespace RestAspNet8VStudio.Logic
{
    public interface IReservationLogic
    {
        List<ReservationVO> FindAll();
        ReservationVO FindById(long id);
        ReservationVO Create(ReservationVO reservation);
        ReservationVO Update(ReservationVO reservation);
        void Delete(long id);
    }
}
