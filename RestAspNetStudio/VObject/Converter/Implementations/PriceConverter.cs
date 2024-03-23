using RestAspNet8VStudio.Model;
using RestAspNetStudio.VObject.Converter;

namespace RestAspNet8VStudio.VObject.Converter.Implementations
{
    public class PriceConverter : IConverter<PriceVO, Price>, IConverter<Price, PriceVO>
    {
        public Price Convert(PriceVO source)
        {
            if (source == null) return null;
            return new Price()
            {
                Id = source.Id,
                RoomId = source.RoomId,
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                Amount = source.Amount,
                Currency = source.Currency
            };
        }

        public List<Price> Convert(List<PriceVO> source)
        {
            if (source == null) return null;
            return source.Select(item => Convert(item)).ToList();
        }

        public PriceVO Convert(Price source)
        {
            if (source == null) return null;
            return new PriceVO()
            {
                Id = source.Id,
                RoomId = source.RoomId,
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                Amount = source.Amount,
                Currency = source.Currency
            };
        }

        public List<PriceVO> Convert(List<Price> source)
        {
            if (source == null) return null;
            return source.Select(item => Convert(item)).ToList();
        }
    }
}
