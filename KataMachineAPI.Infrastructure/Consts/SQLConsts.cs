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
            public const string GetAll = @"SELECT * FROM Reservations";
            public const string GetReservationById = @"SELECT * FROM Reservations where Id = @Id";

            public const string InsertReservation = @"INSERT INTO Reservations
                               (ReservationDate, EmailAdress, MachineNumber, Pin)
                        VALUES (@ReservationDate, @EmailAdress, @MachineNumber, @Pin);";

            public const string DeleteReservation = @"DELETE FROM Reservations where Id = @Id";
        }

        public static class Machine
        {
            public const string GetAll = @"SELECT * FROM Machines";

            public const string IsMachineAvalible = @"SELECT IsOperative FROM Machines";

            public const string UpdateAvalible = @"UPDATE Machines
SET IsOperative = @IsAvalible
WHERE Id = @Id;";

            public const string GetAvalibleIdMachines = @"SELECT Id FROM Machines where IsOperative = 1";
        }
    }
}