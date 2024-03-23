using RestAspNet8VStudio.Model;
using RestAspNetStudio.VObject.Converter;

namespace RestAspNet8VStudio.VObject.Converter.Implementations
{
    public class ReservationConverter : IConverter<ReservationVO, Reservation>, IConverter<Reservation, ReservationVO>
    {
        public Reservation Convert(ReservationVO source)
        {
            if (source == null) return null;
            return new Reservation()
            {
                Id = source.Id,
                UserId = source.UserId,
                RoomId = source.RoomId,
                CheckinDateTime = source.CheckinDateTime,
                CheckoutDateTime = source.CheckoutDateTime

            };
        }

        public List<Reservation> Convert(List<ReservationVO> source)
        {
            if (source == null) return null;
            return source.Select(item => Convert(item)).ToList();
        }

        public ReservationVO Convert(Reservation source)
        {
            if (source == null) return null;
            return new ReservationVO()
            {
                Id = source.Id,
                UserId = source.UserId,
                RoomId = source.RoomId,
                CheckinDateTime = source.CheckinDateTime,
                CheckoutDateTime = source.CheckoutDateTime

            };
        }

        public List<ReservationVO> Convert(List<Reservation> source)
        {
            if (source == null) return null;
            return source.Select(item => Convert(item)).ToList();
        }
    }
}
