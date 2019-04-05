using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ModelLibrary.Model;
using RestService.DButil;
using RestService.Models;

namespace RestService.Controllers
{
    public class ManageHotelEF : Imanage<Hotel>
    {
        HotelContext db = new HotelContext();

        public IEnumerable<Hotel> Get()
        {
            List<Hotel> hotels = new List<Hotel>();
            foreach (var dbHotel in db.DemoHotels)
            {
                hotels.Add(new Hotel(dbHotel.Hotel_No, dbHotel.Name,dbHotel.Address));
            }
            return hotels;
        }

        public Hotel Get(int id)
        {
            DemoHotel demoHotel = db.DemoHotels.Find(id);
                if (demoHotel == null)
                {
                    return null;
                }
            return new Hotel(demoHotel.Hotel_No, demoHotel.Name, demoHotel.Address);
        }

        public bool Post(Hotel hotel)
        {
            DemoHotel demoHotel = new DemoHotel();
            demoHotel.Hotel_No = hotel.HotelNr;
            demoHotel.Address = hotel.Address;
            demoHotel.Name = hotel.Name;
            db.Entry(demoHotel).State = EntityState.Modified;

            db.DemoHotels.Add(demoHotel);

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

    

    public bool Put(int id, Hotel hotel)
        {           
            {
                DemoHotel demoHotel = new DemoHotel();
                demoHotel.Hotel_No = hotel.HotelNr;
                demoHotel.Address = hotel.Address;
                demoHotel.Name = hotel.Name;
                db.Entry(demoHotel).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

                return true;
            }

        }

        public bool Delete(int id)
        {
            DemoHotel dh = db.DemoHotels.Find(id);
            if (dh == null)
            {
                return false;
            }

            db.DemoHotels.Remove(dh);
            db.SaveChanges();

            return true;

        }
    }
}