using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Email.ServiceLibrary.Interfaces;

namespace WundaWashReservations.Email.ServiceLibrary.Services
{
    public class EmailService : IEmailService
    {
        public void SendConfirmationEmail(string email, int machineId, int pin)
        {
            Console.WriteLine($"Email enviado a {email}. Reserva de maquina {machineId}, PIN de desbloqueo: {pin}");
        }
    }
}