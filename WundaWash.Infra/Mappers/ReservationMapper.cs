using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Models;

namespace WundaWash.Infra.Mappers
{
    public class ReservationMapper
    {
        public static Reservation Map(SqlDataReader reader)
        {
            Reservation reservation = new Reservation
            {
                IdReservation = reader.GetInt32(0),
                IdPatron = reader.GetInt32(1),
                IdMachine = reader.GetInt32(2),
                Pin = reader.GetInt32(3),
                DateReservation = reader.GetDateTime(4)
            };
            return reservation;
        }
    }
}
