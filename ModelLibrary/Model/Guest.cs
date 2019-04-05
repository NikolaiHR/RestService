using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model
{
    public class Guest
    {
        private int _guestNr;
        private string _name;
        private string _address;

        public int GuestNr
        {
            get => _guestNr;
            set => _guestNr = value;
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

        public Guest(int guestNr, string name, string address)
        {
            _guestNr = guestNr;
            _name = name;
            _address = address;
        }

        public Guest()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(GuestNr)}: {GuestNr}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }
}
