using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.ADO.Infra.Queries
{
    public static class SqlQueries
    {
        public const string SaveReservation = @"INSERT INTO Reservation VALUES(@Id, @ReservationDate, @MachineId, @Pin, @PhoneNumber, @Email, @Status)";
        public const string UpdateReservationStatus = @"UPDATE Reservation SET Status = @Status WHERE Id = @Id";
        public const string GetReservationIdByPin = @"SELECT Reservation.Id FROM Reservation WHERE MachineId =  @MachineId AND Pin = @Pin";
        public const string GetMachineId = @"SELECT Reservation.MachineId FROM Reservation WHERE Id = @Id";
        public const string GetEmail = @"SELECT Reservation.Email FROM Reservation WHERE Id = @Id";
        public const string GetStatus = @"SELECT Reservation.Status FROM Reservation WHERE Id = @Id";
        public const string DeleteReservation = @"DELETE FROM Reservation WHERE Id = @Id";
    }
}