using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Interfaces;
using WundaWash.Core.Models;
using WundaWash.Infra.Mappers;
using WundaWash.Infra.SqlComponents;

namespace WundaWash.Infra.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        public List<Machine> GetMachinesAvaible()
        {
            List<Machine> _machines = new List<Machine>();
            using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashConnection))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Queries.GetAllMachineUnlock, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Machine machine = MachineMapper.Map(reader);
                        _machines.Add(machine);
                    }
                }
            }
            return _machines;
        }
    }
}
