using LaundryReservation.Infraestructure.EF.Context;
using LaundryServices.Core.Core;
using LaundryServices.Core.Services.IRepository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryReservation.Infraestructure.EF.Respositories
{
    public class ReservationRepository : IReservationRepository
    {

        private readonly LaundryReservationServiceContext _context;
        private readonly DbSet<Reservation> _reservation;
        public ReservationRepository(LaundryReservationServiceContext context)
        {
            _context = context;
            _reservation = context.Set<Reservation>();
        }
        public bool CancelReservation(int id)
        {
            try
            {
                var reservation = _reservation.Find(id);
                if (reservation != null && reservation.Active == false)
                {
                    reservation.Active = false;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Communication error with the database in CancelReservation");
                throw;
            }
        }

        public bool CreateReservation(Reservation reservation)
        {
            try
            {
                var reser = _reservation.Add(reservation);
                _context.SaveChanges();
                if (reser != null) return true;
                else return false;
            }
            catch (Exception e)
            {
                Log.Error(e, "Communication error with the database in CreateReservation");
                throw;
            }
        }

        public List<Reservation> GetAll()
        {
            try
            {
                var reservations = _reservation.ToList();
                return reservations;
            }
            catch (Exception e)
            {
                Log.Error(e, "Communication error with the database in Get Reservations");
                throw;
            }
        }

        public Reservation GetReservationById(int id)
        {
            try
            {
                var reservation = _reservation.Find(id);
                return reservation;
            }
            catch (Exception e)
            {
                Log.Error(e, "Communication error with the database in GetReservationById");
                throw;
            }
        }
    }
}
