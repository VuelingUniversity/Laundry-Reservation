using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_Reservation.Infra
{
    public static class SqlCommands
    {
        public static class Machine
        {
            public static string IsMachineAvaible = @"SELECT * FROM Machine WHERE IsLocked = 0;";
            public static string GetMachineById = @"SELECT * FROM Machine WHERE Id = @Id";
            public static string GetMachines = @"SELECT * FROM Machine";
        }

        public static class Reservation
        {
            public static string GetReservations = @"SELECT * FROM Reservation";
            public static string GetReservationById = @"SELECT * FROM Reservation WHERE Id = @Id";
        }
    }
}