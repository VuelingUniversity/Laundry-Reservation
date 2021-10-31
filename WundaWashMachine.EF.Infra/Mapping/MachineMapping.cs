﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashMachine.EF.Infra.DTO;

namespace WundaWashMachine.EF.Infra.Mapping
{
    public class MachineMapping : EntityTypeConfiguration<Machine>
    {
        public MachineMapping()
        {
            HasKey(a => a.Id);
            ToTable("Machine");
        }
    }
}