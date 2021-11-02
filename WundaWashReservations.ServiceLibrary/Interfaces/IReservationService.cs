using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.Core.Models;

namespace WundaWashReservations.ServiceLibrary.Interfaces
{
    public interface IReservationService
    {
        bool CreateReservation(CreateReservationRequest createRequest);

        void RevertCreateReservation(bool repositorySaveInDBResponse, bool machineLockReponse, string reservationId, int machineId);

        bool ClaimReservation(ClaimReservationRequest claimRequest);

        bool CancelReservation(string reservationId);

        string GenerateReservationId();

        int ChooseWashMachine();

        int GeneratePin();

        void DeleteReservation(string reservationId);
    }
}