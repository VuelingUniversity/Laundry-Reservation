using Laundry_Reservation.Domain.Models;
using Laundry_Reservation.Infra.Mappers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Laundry_Reservation.Infra.Repostiory
{
    public class MachineRepository
    {
        private readonly string _connString;

        public MachineRepository(string connString)
        {
            this._connString = connString;
        }

        public IEnumerable<Machine> GetMachines()
        {
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (var command = new SqlCommand(SqlCommands.Machine.GetMachines, conn))
                {
                    var dataReader = command.ExecuteReader();
                    return MachineMappers.GetMachines(dataReader);
                }
            }
        }

        public Machine GetMachineById(int id)
        {
            Machine machine;
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (var command = new SqlCommand(SqlCommands.Machine.GetMachineById, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    var dataReader = command.ExecuteReader();
                    return MachineMappers.GetMachine(dataReader);
                }
            }
        }
    }
}