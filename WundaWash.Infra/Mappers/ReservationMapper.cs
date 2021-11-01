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
                Id_reservation = reader.GetInt32(0),
                Id_patron = reader.GetInt32(1),
                Id_machine = reader.GetInt32(2),
                Pin = reader.GetInt32(3),
                DateReservation = reader.GetDateTime(4)
            };
            return reservation;
        }
    }
}
