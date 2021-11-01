using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KataMachineAPI.Infrastructure.Mappers
{
    internal class MachineMappers
    {
        public static List<int> GetIdList(SqlDataReader dataReader)
        {
            List<int> machineIds = new List<int>();
            while (dataReader.Read())
            {
                machineIds.Add(dataReader.GetInt32(0));
            }
            return machineIds;
        }
    }
}