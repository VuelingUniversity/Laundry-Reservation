using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashMachine.Core.Models;
using WundaWashMachine.EF.Infra.Mapping;

namespace WundaWashMachine.EF.Infra.Context
{
    public partial class WundaWashMachineContext : DbContext
    {
        public WundaWashMachineContext() : base("WundaWashMachine")
        {
        }

        public DbSet<Machine> Machines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MachineMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}