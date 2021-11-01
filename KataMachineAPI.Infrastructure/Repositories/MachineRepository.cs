using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataMachineAPI.Core.Services;
using KataMachineAPI.Infrastructure.Consts;
using KataMachineAPI.Infrastructure.Mappers;

namespace KataMachineAPI.Infrastructure.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private string _path;

        public MachineRepository(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                _path = SQLConsts.Generic.ConnectionString;
            }
            else
            {
                _path = path;
            }
        }

        public bool IsOperative(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_path))
                {
                    conn.Open();
                    using (var command = new SqlCommand(SQLConsts.Machine.IsMachineAvalible, conn))
                    {
                        command.CommandTimeout = 100;
                        var dataReader = command.ExecuteReader();
                        dataReader.Read();
                        return dataReader.GetBoolean(0);
                    }
                }
            }
            catch (Exception e)
            {
                return false;
                Console.WriteLine(e);
            }
        }

        public void UpdateMachineOperative(int id, bool isAvalible)
        {
            try
            {
                using (var conn = new SqlConnection(_path))
                {
                    conn.Open();
                    using (var command = new SqlCommand(SQLConsts.Machine.UpdateAvalible, conn))
                    {
                        command.CommandTimeout = 100;
                        command.Parameters.AddWithValue("@IsAvalible", isAvalible);
                        command.Parameters.AddWithValue("@Id", id);
                        var rowsSwitched = command.ExecuteNonQuery();
                        if (rowsSwitched < 1)
                        {
                            // Aqui iría un log jeje
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<int> GetAvalibleIdMachines()
        {
            List<int> list = new List<int>();
            try
            {
                using (var conn = new SqlConnection(_path))
                {
                    conn.Open();
                    using (var command = new SqlCommand(SQLConsts.Machine.GetAvalibleIdMachines, conn))
                    {
                        command.CommandTimeout = 100;
                        var dataReader = command.ExecuteReader();
                        dataReader.Read();
                        return MachineMappers.GetIdList(dataReader);
                    }
                }
            }
            catch (Exception e)
            {
                return list;
                Console.WriteLine(e);
            }
        }
    }
}