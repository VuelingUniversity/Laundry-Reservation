using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataMachineAPI.Infrastructure.Consts
{
    public static class SQLConsts
    {
        public static class Generic
        {
            public const string ConnectionString = @"Data Source=(localDB)\Laundry;Initial Catalog=LaundryMachines;Integrated Security=True";
        }

        public static class Reservation
        {
            public const string GetAll = @"select * from Reservations";
            public const string GetReservationById = @"select * from Reservations where Id = @Id";

            public const string InsertReservation = @"INSERT INTO Reservations
                                                        (ReservationDate, EmailAdress, MachineNumber, Pin)
                                                        VALUES (@ReservationDate, @EmailAdress, @MachineNumber, @Pin);";
        }

        public static class Machine
        {
            public const string GetAll = @"select * from Machines";
            public const string IsMachineAvalible = @"select IsAvalible from Machines";

            public const string UpdateAvalible = @"UPDATE Machines
SET IsAvalible = @IsAvalible
WHERE Id = @Id;";
        }
    }
}