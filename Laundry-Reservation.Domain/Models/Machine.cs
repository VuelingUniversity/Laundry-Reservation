using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_Reservation.Domain.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public int Pin { get; set; }
        public bool IsLocked { get; set; }
        public bool Enabled { get; set; }
        public int ReservationId { get; set; }

        public Machine(int id, int pin, bool isLocked = false, bool enabled = true, int reservationId = 0)

        {
            Id = id;
            Pin = pin;
            IsLocked = isLocked;
            ReservationId = reservationId;
            Enabled = enabled;
        }

        public int GetRandomPin()
        {
            Random r = new Random();
            return r.Next(1000, 9999);
        }
    }
}