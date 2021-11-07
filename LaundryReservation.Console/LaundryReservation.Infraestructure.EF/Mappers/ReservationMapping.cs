using LaundryServices.Core.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryReservation.Infraestructure.EF.Mappers
{
    public class ReservationMapping : EntityTypeConfiguration<Reservation>
    {
        public ReservationMapping()
        {
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("Id").IsRequired();
            Property(i => i.ReservationDate).HasColumnName("ReservationDate").IsOptional();
            Property(i => i.Pin).HasColumnName("Pin").IsOptional();
            Property(i => i.Active).HasColumnName("Active").IsOptional();
            HasOptional(i => i.Machine).WithMany().HasForeignKey(i => i.IdMachine);
            ToTable("Reservation");
        }
    }
}
