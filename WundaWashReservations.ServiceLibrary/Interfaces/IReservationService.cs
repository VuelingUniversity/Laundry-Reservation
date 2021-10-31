using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.ServiceLibrary.Interfaces
{
    public interface IReservationService
    {
        bool CreateReservation(DateTime reservationDate, int phoneNumber, string email);

        void RevertCreateReservation(bool repositorySaveInDBResponse, bool machineLockReponse, string reservationId, int machineId);

        bool ClaimReservation(int machineId, int pin);

        bool CancelReservation(string reservationId);

        string GenerateReservationId();

        int ChooseWashMachine();

        int GeneratePin();

        void DeleteReservation(string reservationId);
    }
}