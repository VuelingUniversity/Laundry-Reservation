using LaundryServices.Core.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryReservation.Infraestructure.EF.Mappers
{
   public class MachineMapping: EntityTypeConfiguration<Machine>
    {
        public MachineMapping()
        {
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("Id").IsRequired();
            Property(i => i.Code).HasColumnName("Code").IsOptional();
            Property(i => i.Active).HasColumnName("Active").IsOptional();
            HasMany(i => i.Reservations);
            ToTable("Machine");
        }
    }
}
