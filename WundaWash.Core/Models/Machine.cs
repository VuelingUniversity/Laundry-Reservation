using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWash.Core.Models
{
    public class Machine
    {
        public int Id_machine { get; set; }
        public string Model { get; set; }
        public bool Lock { get; set; }
    }
}
