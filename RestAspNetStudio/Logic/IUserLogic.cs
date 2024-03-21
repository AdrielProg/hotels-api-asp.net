using RestAspNetStudio.Model;

namespace RestAspNetStudio.Logic
{
    public interface IUserLogic
    {
        List<UserVO> FindAll();
        UserVO FindById(long id);
        UserVO Create(UserVO user);
        UserVO Update(UserVO user);
        void Delete(long id);
    }
}
