using LaundryReservation.Infraestructure.EF.Mappers;
using LaundryServices.Core.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryReservation.Infraestructure.EF.Context
{
    public class LaundryReservationServiceContext:DbContext
    {
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Machine> Machine { get; set; }      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //pongo el mapeo y tambien si tiene alguna relacion tipo one-one many-one etc			
            modelBuilder.Configurations.Add(new ReservationMapping());
            modelBuilder.Configurations.Add(new MachineMapping());           
            base.OnModelCreating(modelBuilder);
        }
    }
}
