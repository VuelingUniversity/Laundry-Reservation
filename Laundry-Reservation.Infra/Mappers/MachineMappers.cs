using Laundry_Reservation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Laundry_Reservation.Infra.Mappers
{
    public class MachineMappers
    {
        public static IEnumerable<Machine> GetMachines(SqlDataReader reader)
        {
            List<Machine> list = new List<Machine>();
            while (reader.Read())
            {
                list.Add(new Machine(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetBoolean(2),
                    reader.GetBoolean(3),
                    reader.GetInt32(4)
                    ));
            }
            return list;
        }

        public static Machine GetMachine(SqlDataReader reader)
        {
            reader.Read();
            return new Machine(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetBoolean(2),
                reader.GetBoolean(3),
                reader.GetInt32(4)
                );
        }
    }
}