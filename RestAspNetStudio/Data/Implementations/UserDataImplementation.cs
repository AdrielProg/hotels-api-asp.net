using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestAspNetStudio.Model;
using RestAspNetStudio.Model.Context;

namespace RestAspNetStudio.Data.Implementations
{
    public class UserDataImplementation : IUserData
    {       
        private MySQLContext _context;

        public UserDataImplementation(MySQLContext context){ _context = context;}
        public User Create(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            } catch (Exception)
            {
                throw;
            }
            return user;
        }

        public void Delete(long id)
        {
            var result = _context.Users.SingleOrDefault(u => u.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<User> FindAll()
        {
         return _context.Users.ToList();
        }


        public User FindById(long id)
        {
            //returno do SingleOrDefault é o proprio objeto
            return _context.Users.SingleOrDefault(u => u.Id.Equals(id));
            
        }

        public User Update(User user)
        {
            if (!Exists(user.Id)) return new User();
            var result = _context.Users.SingleOrDefault(u => u.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }

        private bool Exists(long id)
        {
            //retono do Any é um boolean 
            return _context.Users.Any(u => u.Id.Equals(id));
        }
    }
}
