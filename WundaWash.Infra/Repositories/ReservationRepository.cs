using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Models;
using WundaWash.Infra.SqlComponents;

namespace WundaWash.Infra.Repositories
{
    public class ReservationRepository
    {
        public bool InsertReservation(Reservation reservation)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashConnection))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(Queries.InsertNewReservation, connection))
                    {
                        command.Parameters.AddWithValue("@IdPatron", reservation.IdPatron);
                        command.Parameters.AddWithValue("@IdMachine", reservation.IdMachine);
                        command.Parameters.AddWithValue("@Pin", reservation.Pin);
                        command.Parameters.AddWithValue("@DateReservation", reservation.DateReservation);
                        var reader = command.ExecuteNonQuery();
                        while (reader > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
       
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
