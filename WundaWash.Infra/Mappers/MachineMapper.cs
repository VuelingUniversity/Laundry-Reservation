using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Models;

namespace WundaWash.Infra.Mappers
{
   public class MachineMapper
    {
        public static Machine Map(SqlDataReader reader)
        {
            Machine machine = new Machine
            {
                Id_machine = reader.GetInt32(0),
                Model = reader.GetString(1),
                Lock = reader.GetBoolean(2)
            };
            return machine;
        }
    }
}
