using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.ADO.Infra.Queries
{
    public static class SqlQueries
    {
        public const string SaveReservation = "INSERT INTO Reservation VALUES('{0}', '{1}', {2}, {3}, {4}, '{5}', {6})";
        public const string UpdateReservationStatus = "UPDATE Reservation SET Status = {1} WHERE Id = '{0}'";
        public const string GetReservationIdByPin = "SELECT Reservation.Id FROM Reservation WHERE MachineId = {0} AND Pin = {1}";
        public const string GetMachineId = "SELECT Reservation.MachineId FROM Reservation WHERE Id = '{0}'";
        public const string GetEmail = "SELECT Reservation.Email FROM Reservation WHERE Id = '{0}'";
        public const string GetStatus = "SELECT Reservation.Status FROM Reservation WHERE Id = '{0}'";
        public const string DeleteReservation = "DELETE FROM Reservation WHERE Id = '{0}'";
    }
}