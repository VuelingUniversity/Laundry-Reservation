using KataMachineAPI.Core.Models;
using KataMachineAPI.Core.Services;
using Serilog;
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
            var machineSelected = -1;
            if (idMachineList.Count == 0)
            {
                Log.Warning("LaundryManager: Is not avalible machine for user.");
                return false;
            }
            if (idMachineList.Count == 1)
            {
                Log.Debug("LaundryManager: The last machine is reserved for user.");
                machineSelected = idMachineList[0];
            }
            else
            {
                machineSelected = idMachineList[new Random().Next(0, idMachineList.Count)];
                Log.Debug($"LaundryManager: The machine {machineSelected} is reservated.");
            }
            reservation.MachineNumber = machineSelected;
            var isReservationCreated = _reservationRepository.CreateReservation(reservation);
            if (isReservationCreated)
                _machineRepository.UpdateMachineOperative(machineSelected, false);
            return isReservationCreated;
        }

        public bool ClaimReservation(int id, int PIN)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            if (reservation == null)
            {
                Log.Warning($"LaundryManager: Someone tried to claim a wrong Id [Id : {id}].");
                return false;
            }
            if (reservation.PIN != PIN)
            {
                Log.Warning($"LaundryManager: Someone failed the PIN [Id : {id} - PIN {PIN}].");
                return false;
            }
            Log.Debug($"LaundryManager: The client {id} calimed his reservation.");
            return DeleteReservation(id);
        }

        public bool DeleteReservation(int id)
        {
            var machineToBreakFree = _reservationRepository.GetReservationById(id);
            var isReservationDeleted = _reservationRepository.DeleteReservation(id);
            if (isReservationDeleted)
            {
                _machineRepository.UpdateMachineOperative(machineToBreakFree.MachineNumber, true);
                Log.Information($"LaundryManager: Machine{machineToBreakFree.MachineNumber} is now free and the resevation {id} is deleted.");
            }
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