using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestService.DButil;

namespace RestService.Models
{
    [Table("DemoBooking")]
    public partial class DemoBooking
    {
        [Key]
        public int Booking_id { get; set; }

        public int Hotel_No { get; set; }

        public int Guest_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_From { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_To { get; set; }

        public int Room_No { get; set; }

        public virtual DemoGuest DemoGuest { get; set; }

        public virtual DemoRoom DemoRoom { get; set; }
    }
}
