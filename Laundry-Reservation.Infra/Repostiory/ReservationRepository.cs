using Laundry_Reservation.Domain.Models;
using Laundry_Reservation.Infra.Mappers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Laundry_Reservation.Infra.Repostiory
{
    public class ReservationRepository
    {
        private readonly string _connString;

        public ReservationRepository(string connString)
        {
            _connString = connString;
        }

        public Reservation GetReservation(int id)
        {
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (var command = new SqlCommand(SqlCommands.Reservation.GetReservationById, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    var reader = command.ExecuteReader();
                    return ReservationMapping.GetReservation(reader);
                }
            }
        }

        public IEnumerable<Reservation> GetReservations()
        {
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (var command = new SqlCommand(SqlCommands.Reservation.GetReservationById, conn))
                {
                    var reader = command.ExecuteReader();
                    return ReservationMapping.GetReservations(reader);
                }
            }
        }
    }
}