using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Enums;
using WundaWashReservations.Core.Models;

namespace WundaWashReservations.ADO.Infra.Mappers
{
    public static class ReservationMapper
    {
        public static Reservation Map(SqlDataReader reader)
        {
            return new Reservation
            {
                Id = reader.GetString(0),
                ReservationDate = reader.GetDateTime(1),
                MachineId = reader.GetInt32(2),
                Pin = reader.GetInt32(3),
                PhoneNumber = reader.GetInt32(4),
                Email = reader.GetString(5),
                Status = (StatusEnum)reader.GetInt32(6)
            };
        }
    }
}