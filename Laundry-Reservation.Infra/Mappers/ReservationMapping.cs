using Laundry_Reservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Laundry_Reservation.Infra.Mappers
{
    public class ReservationMapping
    {
        public static IEnumerable<Reservation> GetReservations(SqlDataReader reader)
        {
            List<Reservation> list = new List<Reservation>();
            while (reader.Read())
            {
                list.Add(new Reservation(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetInt32(2),
                    reader.GetString(3)
                    ));
            }
            return list;
        }

        public static Reservation GetReservation(SqlDataReader reader)
        {
            reader.Read();
            return new Reservation(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetInt32(2),
                    reader.GetString(3)
                );
        }
    }
}