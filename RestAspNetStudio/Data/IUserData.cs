using RestAspNetStudio.Model;

namespace RestAspNetStudio.Data
{
    public interface IUserData
    {
        List<User> FindAll();
        User FindById(long id);
        User Create(User user);
        User Update(User user);
        void Delete(long id);
    }
}
