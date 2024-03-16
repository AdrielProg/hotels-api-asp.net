using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestAspNetStudio.Data;
using RestAspNetStudio.Model;
using RestAspNetStudio.Model.Context;

namespace RestAspNetStudio.Logic.Implementations
{
    public class UserLogicImplementation : IUserLogic
    {       
       private readonly IUserData _data;

        public UserLogicImplementation(IUserData data){ _data = data;}
        public User Create(User user)
        {
            
            return _data.Create(user);
        }

        public void Delete(long id)
        {
           _data.Delete(id);
        }

        public List<User> FindAll()
        {
         return _data.FindAll();
        }


        public User FindById(long id)
        {
            //returno do SingleOrDefault é o proprio objeto
            return _data.FindById(id);
            
        }

        public User Update(User user)
        {
          
            return _data.Update(user);
        }

    }
}
