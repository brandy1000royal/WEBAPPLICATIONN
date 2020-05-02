using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebZuber.Contracts;
using WebZuber.Data;

namespace WebZuber.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly ApplicationDbContext _db;
        public DriverRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Driver Entity)
        {
            _db.Drivers.Add(Entity);
            return Save();
        }


        public bool Delete(Driver Entity)
        {
            _db.Drivers.Remove(Entity);
            return Save();
        }

        public ICollection<Driver> FindAll()
        {
            var Driver = _db.Drivers.ToList();
            return Driver;
        }

        public Driver FindById(int id)
        {
            var Driver = _db.Drivers.Find(id);

            return Driver;
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

        public bool Update(Driver Entity)
        {
            _db.Drivers.Update(Entity);
            return Save();
        }

    }
}



