using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestAspNetStudio.Model;
using RestAspNetStudio.Model.Context;

namespace RestAspNetStudio.Data.Implementations
{
    public class HotelDataImplementation : IHotelData
    {       
        private MySQLContext _context;

        public HotelDataImplementation(MySQLContext context){ _context = context;}
        public Hotel Create(Hotel hotel)
        {
            try
            {
                _context.Add(hotel);
                _context.SaveChanges();
            } catch (Exception)
            {
                throw;
            }
            return hotel;
        }

        public void Delete(long id)
        {
            var result = _context.Hotels.SingleOrDefault(u => u.Id.Equals(id));
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

        public List<Hotel> FindAll()
        {
         return _context.Hotels.ToList();
        }


        public Hotel FindById(long id)
        {
            //returno do SingleOrDefault é o proprio objeto
            return _context.Hotels.SingleOrDefault(u => u.Id.Equals(id));
            
        }

        public Hotel Update(Hotel hotel)
        {
            if (!Exists(hotel.Id)) return new Hotel();
            var result = _context.Hotels.SingleOrDefault(u => u.Id.Equals(hotel.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(hotel);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return hotel;
        }

        private bool Exists(long id)
        {
            //retono do Any é um boolean 
            return _context.Hotels.Any(u => u.Id.Equals(id));
        }
    }
}
