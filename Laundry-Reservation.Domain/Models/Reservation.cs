using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_Reservation.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public Reservation(int id, DateTime reservationDate, int phoneNumber, string email)
        {
            Id = id;
            ReservationDate = reservationDate;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}