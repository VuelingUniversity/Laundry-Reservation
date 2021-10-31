﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.Email.ServiceLibrary.Interfaces
{
    public interface IEmailService
    {
        void SendConfirmationEmail(string email, int machineId, int pin);

        void SendCancelReservationEmail(string email, string reservationId);
    }
}