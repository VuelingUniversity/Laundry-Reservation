using LaundryServices.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryServices.Core.Services.IRepository
{
    public interface IMachineRepository
    {
        List<Machine> GetAllEnableMachine();
        bool IsEnable(int id);
        void UpdateMachineEnable(int id, bool Active);       
    }
}
