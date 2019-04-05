using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model
{
    public class Room
    {
        private int _roomNr;
        private int _hotelNr;
        private string _type;
        private double _price;

        public int RoomNr
        {
            get => _roomNr;
            set => _roomNr = value;
        }

        public int HotelNr
        {
            get => _hotelNr;
            set => _hotelNr = value;
        }

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public Room(int roomNr, int hotelNr, string type, double price)
        {
            _roomNr = roomNr;
            _hotelNr = hotelNr;
            _type = type;
            _price = price;
        }

        public Room()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(RoomNr)}: {RoomNr}, {nameof(HotelNr)}: {HotelNr}, {nameof(Type)}: {Type}, {nameof(Price)}: {Price}";
        }
    }
}
