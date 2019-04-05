using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model
{
    public class Hotel
    {
        private int _hotelNr;
        private string _name;
        private string _address;

        public int HotelNr
        {
            get => _hotelNr;
            set => _hotelNr = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public Hotel(int hotelNr, string name, string address)
        {
            _hotelNr = hotelNr;
            _name = name;
            _address = address;
        }

        public Hotel()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(HotelNr)}: {HotelNr}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }
}
