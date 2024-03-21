using RestAspNetStudio.Model;

namespace RestAspNetStudio.VObject.Converter.Implementations
{
    public class UserConverter : IConverter<UserVO, User>, IConverter<User, UserVO>
    {
        public User Convert(UserVO input)
        {
            if (input == null) return null; 
            return new User()
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Adress = input.Adress,
                Gender = input.Gender
            };
        }
       public List<User> Convert(List<UserVO> input)
        {
            if(input == null) return null;
            return input.Select(user => Convert(user)).ToList();
        }

        public UserVO Convert(User input)
        {
            if (input == null) return null;
            return new UserVO()
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Adress = input.Adress,
                Gender = input.Gender
            };
        }

        public List<UserVO> Convert(List<User> input)
        {
            if (input == null) return null;
            return input.Select(user => Convert(user)).ToList();
        }
    }
}
