
using RestAspNetStudio.Data.Generic;
using RestAspNetStudio.Model;
using RestAspNetStudio.VObject.Converter.Implementations;
using RestAspNetStudio.VObject;

namespace RestAspNetStudio.Logic.Implementations
{
    public class UserLogicImplementation : IUserLogic
    {       
       private readonly IGenericData<User> _data;
        private readonly UserConverter _converter;

        public UserLogicImplementation(IGenericData<User> data)
        {
            _data = data;
            _converter = new UserConverter();
        }
        public UserVO Create(UserVO user)
        {
            var userEntity = _converter.Convert(user);
            userEntity = _data.Create(userEntity); 
            return _converter.Convert(userEntity);
            
        }

        public void Delete(long id)
        {
           _data.Delete(id);
        }

        public List<UserVO> FindAll()
        {
         return _converter.Convert(_data.FindAll());
        }


        public UserVO FindById(long id)
        {
            //returno do SingleOrDefault é o proprio objeto
            return _converter.Convert(_data.FindById(id));
            
        }

        public UserVO Update(UserVO user)
        {

            var userEntity = _converter.Convert(user);
            userEntity = _data.Update(userEntity);
            return _converter.Convert(userEntity);
        }

    }
}
