﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Services;

namespace WundaWashReservations.ADO.Infra.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public bool CreateReservation(DateTime reservationDate, int phoneNumber, string email)
        {
            throw new NotImplementedException();
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