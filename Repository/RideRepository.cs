using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebZuber.Contracts;
using WebZuber.Data;

namespace WebZuber.Repository
{
    public class RideRepository : IRideRepository
    {
        private readonly ApplicationDbContext _db;
        public RideRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Ride Entity)
        {
            _db.Rides.Add(Entity);
            return Save();
        }


        public bool Delete(Ride Entity)
        {
            _db.Rides.Remove(Entity);
            return Save();
        }

        public ICollection<Ride> FindAll()
        {
            var Ride = _db.Rides.ToList();
            return Ride;
        }

        public Ride FindById(int id)
        {
            var Ride = _db.Rides.Find(id);

            return Ride;
        }

        public bool IsExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Ride Entity)
        {
            _db.Rides.Update(Entity);
            return Save();
        }
    }
}