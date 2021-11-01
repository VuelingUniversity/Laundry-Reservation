using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataMachineAPI.Core.Services;

namespace KataMachineAPI.Infrastructure.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        public MachineRepository(string path)
        {
        }

        public bool IsOperative(int id)
        {
            return true;
        }

        public void UpdateMachineOperative(int id, bool isOperative)
        {
        }
    }
}