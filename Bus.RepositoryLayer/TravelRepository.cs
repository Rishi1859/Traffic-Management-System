using Bus.DataLayer;
using Bus.DomainModels;
using Bus.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bus.RepositoryLayer
{
    public class TravelRepository : ITravelRepository
    {
        private readonly BusDbContext _db;

        public TravelRepository(BusDbContext db)
        {
            _db = db;
        }

        public List<BusDetails> GetAllBusDetails()
        {
            var busData = _db.Buses.ToList();
            return busData;
        }

        public BusDetails GetBusById(int id)
        {
            var singleData = _db.Buses.FirstOrDefault(b => b.BusId == id);
            return singleData;
        }

        public BusDetails AddBus(BusDetails busDetails)
        {
            _db.Buses.Add(busDetails);
            _db.SaveChanges();
            return busDetails;
        }

        public BusDetails EditBus(int id, BusDetails busDetails)
        {
            var res = _db.Buses.FirstOrDefault(e => e.BusId == id);
            res.BusName = busDetails.BusName;
            res.BusCategory = busDetails.BusCategory;
            res.Capacity = busDetails.Capacity;
            res.Trips = busDetails.Trips;

            _db.SaveChanges();
            return res;
        }

        public BusDetails DeleteBus(int id)
        {
            var delBusData = _db.Buses.FirstOrDefault(c => c.BusId == id);
            _db.Buses.Remove(delBusData);
            _db.SaveChanges();
            return delBusData;
        }
    }
}
