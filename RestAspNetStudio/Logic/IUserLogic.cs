using RestAspNetStudio.Model;

namespace RestAspNetStudio.Logic
{
    public interface IUserLogic
    {
        List<User> FindAll();
        User FindById(long id);
        User Create(User user);
        User Update(User user);
        void Delete(long id);
    }
}
