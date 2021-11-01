using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Models;

namespace WundaWash.ServiceLibrary.Interfaces
{
    public interface IPatronService
    {
        List<Patron> GetAllPatrons();
    }

}
