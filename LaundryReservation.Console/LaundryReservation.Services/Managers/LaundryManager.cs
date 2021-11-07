
using LaundryServices.Core.Core;
using LaundryServices.Core.Services.IManager;
using LaundryServices.Core.Services.IRepository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryReservation.Services.Managers
{
    public class LaundryManager : ILaundryManager
    {
        IMachineRepository _machineRepository;
        IReservationRepository _reservationRespository;
        public LaundryManager(IMachineRepository machineRepository, IReservationRepository reservationRepository )
        {
            _reservationRespository = reservationRepository;
            _machineRepository = machineRepository;
        }

        public bool CreateReservation(Reservation reservation)
        {
            var idMachineList = _machineRepository.GetAllEnableMachine();
            var machineSelected = 0;
            if (idMachineList.Count == 0)
            {
                Log.Warning("LaundryManager: Is not avalible machine for user.");
                return false;
            }
            if (idMachineList.Count == 1)
            {
                Log.Debug("LaundryManager: The last machine is reserved for user.");
                machineSelected = idMachineList[0].Id;
            }
            else
            {
                machineSelected = idMachineList[new Random().Next(0, idMachineList.Count)].Id;
                Log.Debug($"LaundryManager: The machine {machineSelected} is reservated.");
            }
            reservation.IdMachine = machineSelected;
            var reservationCreate = _reservationRespository.CreateReservation(reservation);
            if (reservationCreate == true)
                _machineRepository.UpdateMachineEnable(machineSelected, false);
            return reservationCreate;
        }

        public bool DeleteReservation(int id)
        {
            var activeMachine = _reservationRespository.GetReservationById(id);
            var cancelReservation = _reservationRespository.CancelReservation(id);
            if (cancelReservation == true)
            {
                _machineRepository.UpdateMachineEnable(activeMachine.Id, true);
                Log.Information($"LaundryManager: Machine{activeMachine.Id} is now free and the resevation {id} is deleted.");
            }
            return cancelReservation;
        }

        public List<Reservation> GetReservations()
        {
            return _reservationRespository.GetAll();
        }
    }
}
