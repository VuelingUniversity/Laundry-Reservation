using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Services;

namespace WundaWashReservations.Email.Infra.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public void SendConfirmationEmail(string email, string ReservationId, int machineId, int pin)
        {
            try
            {
                // usuario -> {email}
                // mensaje -> Reserva {ReservationId} creada para la lavadora {machineId} con PIN de desbloqueo: {pin}
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error to sendConfirmationEmail");
                throw;
            }
        }

        public void SendCancelReservationEmail(string email, string reservationId)
        {
            try
            {
                // usuario -> email
                // mensaje -> Reserva {reservationId} cancelada
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error to sendCandelReservationEmail");
                throw;
            }
        }
    }
}