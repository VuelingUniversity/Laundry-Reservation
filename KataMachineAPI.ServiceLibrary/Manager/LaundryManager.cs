using KataMachineAPI.Core.Models;
using KataMachineAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataMachineAPI.ServiceLibrary.Manager
{
    public class LaundryManager : ILaundryManager
    {
        private IMachineRepository _machineRepository;
        private IReservationRepository _reservationRepository;

        public LaundryManager(IMachineRepository machineRepo, IReservationRepository reservationRepo)
        {
            _machineRepository = machineRepo;
            _reservationRepository = reservationRepo;
        }

        public bool CreateReservation(Reservation reservation)
        {
            var idMachineList = _machineRepository.GetAvalibleIdMachines();
            var machineSelected = idMachineList[new Random().Next(0, idMachineList.Count)];
            reservation.MachineNumber = machineSelected;
            var isReservationCreated = _reservationRepository.CreateReservation(reservation);
            if (isReservationCreated)
                _machineRepository.UpdateMachineOperative(machineSelected, false);
            return isReservationCreated;
        }

        public bool ClaimReservation(int id, int PIN)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            if (reservation.PIN != PIN)
                return false;
            DeleteReservation(id);
            return true;
        }

        public bool DeleteReservation(int id)
        {
            var isReservationDeleted = _reservationRepository.DeleteReservation(id);

            if (isReservationDeleted)
                _machineRepository.UpdateMachineOperative(id, true);
            return isReservationDeleted;
        }

        public List<Reservation> GetReservations()
        {
            return _reservationRepository.GetAll();
        }

        public bool Lock(string reservationId, DateTime reservationDateTime, int pin)
        {
            throw new NotImplementedException();
        }

        public void Unlock(string reservationId)
        {
            throw new NotImplementedException();
        }
    }
}