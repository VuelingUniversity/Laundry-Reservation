using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Enums;
using WundaWashReservations.Core.Models;

namespace WundaWashReservations.Core.Services
{
    public interface IReservationRepository
    {
        bool SaveReservation(Reservation reservation);

        bool UpdateReservationStatus(string reservationId, StatusEnum status);

        string GetReservationIdByPin(int machineId, int pin);

        int GetMachineId(string reservationId);

        string GetEmail(string reservationId);
    }
}