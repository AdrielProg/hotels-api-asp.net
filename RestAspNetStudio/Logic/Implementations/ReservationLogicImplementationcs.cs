
using RestAspNet8VStudio.Model;
using RestAspNet8VStudio.VObject.Converter.Implementations;
using RestAspNet8VStudio.VObject;
using RestAspNetStudio.Data.Generic;

namespace RestAspNet8VStudio.Logic.Implementations
{
    public class ReservationLogicImplementation : IReservationLogic
    {
        private readonly IGenericData<Reservation> _data;
        private readonly ReservationConverter _converter;

        public ReservationLogicImplementation(IGenericData<Reservation> data)
        {
            _data = data;
            _converter = new ReservationConverter();
        }

        public ReservationVO Create(ReservationVO reservation)
        {
            var ReservationEntity = _converter.Convert(reservation);
            ReservationEntity = _data.Create(ReservationEntity);
            return _converter.Convert(ReservationEntity);
        }

        public void Delete(long id)
        {
            _data.Delete(id);
        }

        public List<ReservationVO> FindAll()
        {
            return _converter.Convert(_data.FindAll());
        }
        public ReservationVO FindById(long id)
        {
            return _converter.Convert(_data.FindById(id));
        }
        public ReservationVO Update(ReservationVO reservation)
        {
            var ReservationEntity = _converter.Convert(reservation);
            ReservationEntity = _data.Update(ReservationEntity);
            return _converter.Convert(ReservationEntity);
        }
    }
}
