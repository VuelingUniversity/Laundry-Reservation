using KataMachineAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataMachineAPI.Infrastructure.Mappers
{
    public static class ReservationMappers
    {
        public static List<Reservation> GetReservationList(SqlDataReader dataReader)
        {
            List<Reservation> reservations = new List<Reservation>();
            while (dataReader.Read())
            {
                reservations.Add(new Reservation
                {
                    Id = dataReader.GetInt32(0),
                    ReservationDate = dataReader.GetDateTime(1),
                    EmailAdress = dataReader.GetString(2),
                    MachineNumber = dataReader.GetInt32(3),
                    PIN = dataReader.GetInt32(4)
                });
            }
            return reservations;
        }

        public static Reservation GetReservation(SqlDataReader dataReader)
        {
            dataReader.Read();
            return new Reservation
            {
                Id = dataReader.GetInt32(0),
                ReservationDate = dataReader.GetDateTime(1),
                EmailAdress = dataReader.GetString(2),
                MachineNumber = dataReader.GetInt32(3),
                PIN = dataReader.GetInt32(4)
            };
        }
    }
}