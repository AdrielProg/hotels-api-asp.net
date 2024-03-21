using RestAspNetStudio.Model;

namespace RestAspNetStudio.VObject.Converter.Implementations
{
    public class HotelConverter : IConverter<HotelVO, Hotel>, IConverter<Hotel, HotelVO>
    {
        public Hotel Convert(HotelVO input)
        {
            if (input == null) return null;
            return new Hotel()
            {
                Id = input.Id,
                Name = input.Name,
                Adress = input.Adress,
                Phone = input.Phone,
                Description = input.Description,
                Rating = input.Rating

            };
        }

        public List<Hotel> Convert(List<HotelVO> input)
        {
            if (input == null) return null; 
            return input.Select(hotel => Convert(hotel)).ToList();
        }

        public HotelVO Convert(Hotel input)
        {
            if (input == null) return null;
            return new HotelVO()
            {
                Id = input.Id,
                Name = input.Name,
                Adress = input.Adress,
                Phone = input.Phone,
                Description = input.Description,
                Rating = input.Rating

            };
        }

        public List<HotelVO> Convert(List<Hotel> input)
        {
            if (input == null) return null;
            return input.Select(hotel => Convert(hotel)).ToList();
        }
    }
}
