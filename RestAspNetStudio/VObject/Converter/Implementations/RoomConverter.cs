using RestAspNetStudio.Model;

namespace RestAspNetStudio.VObject.Converter.Implementations
{
    public class RoomConverter : IConverter<RoomVO, Room>, IConverter<Room, RoomVO>
    {
        public Room Convert(RoomVO input)
        {
            if (input == null) return null;
            return new Room()
            {
                Id = input.Id,
                HotelId = input.HotelId,
                RoomNumber = input.RoomNumber,
                Capacity = input.Capacity,
                Description = input.Description,
                Photos = input.Photos
            };
        }

        public List<Room> Convert(List<RoomVO> input)
        {
            if (input == null) return null;
            return input.Select(room => Convert(room)).ToList();
        }

        public RoomVO Convert(Room input)
        {
            if (input == null) return null;
            return new RoomVO()
            {
                Id = input.Id,
                HotelId = input.HotelId,
                RoomNumber = input.RoomNumber,
                Capacity = input.Capacity,
                Description = input.Description,
                Photos = input.Photos
            };
        }

        public List<RoomVO> Convert(List<Room> input)
        {
            if (input == null) return null;
            return input.Select(room => Convert(room)).ToList();
        }

    }
}