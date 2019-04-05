using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Model
{
    public class Booking
    {
        private int _bookingId;
        private Room _room;
        private Guest _guest;
        private DateTime fraDato;
        private DateTime tilDato;

        public Booking(int bookingId, Room room, Guest guest, DateTime fraDato, DateTime tilDato)
        {
            _bookingId = bookingId;
            _room = room;
            _guest = guest;
            this.fraDato = fraDato;
            this.tilDato = tilDato;
        }

        public Booking()
        {
            
        }

        public int BookingId
        {
            get => _bookingId;
            set => _bookingId = value;
        }

        public Room Room
        {
            get => _room;
            set => _room = value;
        }

        public Guest Guest
        {
            get => _guest;
            set => _guest = value;
        }

        public DateTime FraDato
        {
            get => fraDato;
            set => fraDato = value;
        }

        public DateTime TilDato
        {
            get => tilDato;
            set => tilDato = value;
        }

        public override string ToString()
        {
            return $"{nameof(BookingId)}: {BookingId}, {nameof(Room)}: {Room}, {nameof(Guest)}: {Guest}, {nameof(FraDato)}: {FraDato}, {nameof(TilDato)}: {TilDato}";
        }
    }
}
