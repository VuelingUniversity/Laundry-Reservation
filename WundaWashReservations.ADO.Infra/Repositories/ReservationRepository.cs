using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.ADO.Infra.Connection;
using WundaWashReservations.ADO.Infra.Queries;
using WundaWashReservations.Core.Models;
using WundaWashReservations.Core.Services;

namespace WundaWashReservations.ADO.Infra.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public bool SaveReservation(Reservation reservation)
        {
            try
            {
                bool result = false;
                using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashReservationsConnection))
                {
                    connection.Open();
                    StringBuilder stringBuilder = new StringBuilder();
                    using (SqlCommand command = new SqlCommand(stringBuilder.AppendFormat(SqlQueries.SaveReservation, reservation.Id, reservation.ReservationDate, reservation.MachineId, reservation.Pin, reservation.PhoneNumber, reservation.Email).ToString(), connection))
                    {
                        int rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            result = true;
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                // log excepcion DB.
                throw;
            }
        }

        public bool ClaimReservation(int machineId, int pin)
        {
            throw new NotImplementedException();
        }

        public bool CancelReservation(int id)
        {
            throw new NotImplementedException();
        }
    }
}