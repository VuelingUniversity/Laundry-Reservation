using KataMachineAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataMachineAPI.Core.Services;
using KataMachineAPI.Infrastructure.Consts;
using System.Data.SqlClient;
using KataMachineAPI.Infrastructure.Mappers;

namespace KataMachineAPI.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public string _path;

        public ReservationRepository(string path)
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

        public List<Reservation> GetAll()
        {
            var airlineList = new List<Reservation>();
            try
            {
                using (var conn = new SqlConnection(_path))
                {
                    conn.Open();
                    using (var command = new SqlCommand(SQLConsts.Reservation.GetAll, conn))
                    {
                        command.CommandTimeout = 100;
                        var dataReader = command.ExecuteReader();
                        airlineList = ReservationMappers.GetReservationList(dataReader);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return airlineList;
        }

        public Reservation GetReservationById(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_path))
                {
                    conn.Open();
                    using (var command = new SqlCommand(SQLConsts.Reservation.GetReservationById, conn))
                    {
                        command.CommandTimeout = 100;
                        command.Parameters.AddWithValue("@Id", id);
                        var dataReader = command.ExecuteReader();
                        return ReservationMappers.GetReservation(dataReader);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        // Reference -> LockMachine
        public bool CreateReservation(Reservation reservation)
        {
            try
            {
                using (var conn = new SqlConnection(_path))
                {
                    conn.Open();
                    using (var command = new SqlCommand(SQLConsts.Reservation.InsertReservation, conn))
                    {
                        command.CommandTimeout = 100;
                        command.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
                        command.Parameters.AddWithValue("@EmailAdress", reservation.EmailAdress);
                        command.Parameters.AddWithValue("@MachineNumber", reservation.MachineNumber);
                        command.Parameters.AddWithValue("@Pin", reservation.PIN);
                        var x = command.ToString();
                        var dataReader = command.ExecuteNonQuery();
                        if (dataReader > 0)
                            return true;
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // Reference -> UnLockMachine
        public bool DeleteReservation(int id)
        {
            try
            {
                using (var conn = new SqlConnection(_path))
                {
                    conn.Open();
                    using (var command = new SqlCommand(SQLConsts.Reservation.DeleteReservation, conn))
                    {
                        command.CommandTimeout = 100;
                        command.Parameters.AddWithValue("@Id", id);
                        var dataReader = command.ExecuteNonQuery();
                        return dataReader > 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateReservation(int TargetId, Reservation reservation)
        {
            return true;
        }
    }
}