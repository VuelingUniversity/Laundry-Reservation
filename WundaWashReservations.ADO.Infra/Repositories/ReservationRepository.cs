using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWashReservations.ADO.Infra.Connection;
using WundaWashReservations.ADO.Infra.Queries;
using WundaWashReservations.Core.Enums;
using WundaWashReservations.Core.Models;
using WundaWashReservations.Core.Services;

namespace WundaWashReservations.ADO.Infra.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public bool SaveReservation(Reservation reservation)
        {
            try
            {
                bool result = false;
                using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashReservationsConnection))
                {
                    connection.Open();
                    StringBuilder stringBuilder = new StringBuilder();
                    using (SqlCommand command = new SqlCommand(stringBuilder.AppendFormat(SqlQueries.SaveReservation, reservation.Id, reservation.ReservationDate, reservation.MachineId, reservation.Pin, reservation.PhoneNumber, reservation.Email, (Int32)reservation.Status).ToString(), connection))
                    {
                        int rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            result = true;
                        }
                    }
                }
                return result;
            }
            catch (Exception exception)
            {
                Log.Error("Communication error with the database in SaveReservation", exception);
                throw;
            }
        }

        public bool UpdateReservationStatus(string reservationId, StatusEnum status)
        {
            try
            {
                bool result = false;
                using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashReservationsConnection))
                {
                    connection.Open();
                    StringBuilder stringBuilder = new StringBuilder();
                    using (SqlCommand command = new SqlCommand(stringBuilder.AppendFormat(SqlQueries.UpdateReservationStatus, reservationId, (Int32)status).ToString(), connection))
                    {
                        int rows = command.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            result = true;
                        }
                    }
                }
                return result;
            }
            catch (Exception exception)
            {
                Log.Error("Communication error with the database in UpdateReservationStatus", exception);
                throw;
            }
        }

        public string GetReservationIdByPin(int machineId, int pin)
        {
            try
            {
                string reservationId = string.Empty;
                using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashReservationsConnection))
                {
                    connection.Open();
                    StringBuilder stringBuilder = new StringBuilder();
                    using (SqlCommand command = new SqlCommand(stringBuilder.AppendFormat(SqlQueries.GetReservationIdByPin, machineId, pin).ToString(), connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        reservationId = reader.GetString(0);
                    }
                }
                return reservationId;
            }
            catch (Exception exception)
            {
                Log.Error("Communication error with the database in GetReservationIdByPin", exception);
                throw;
            }
        }

        public int GetMachineId(string reservationId)
        {
            try
            {
                int machineId = 0;
                using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashReservationsConnection))
                {
                    connection.Open();
                    StringBuilder stringBuilder = new StringBuilder();
                    using (SqlCommand command = new SqlCommand(stringBuilder.AppendFormat(SqlQueries.GetMachineId, reservationId).ToString(), connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        machineId = reader.GetInt32(0);
                    }
                }
                return machineId;
            }
            catch (Exception exception)
            {
                Log.Error("Communication error with the database in GetMachineId", exception);
                throw;
            }
        }

        public string GetEmail(string reservationId)
        {
            try
            {
                string email = string.Empty;
                using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashReservationsConnection))
                {
                    connection.Open();
                    StringBuilder stringBuilder = new StringBuilder();
                    using (SqlCommand command = new SqlCommand(stringBuilder.AppendFormat(SqlQueries.GetEmail, reservationId).ToString(), connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        email = reader.GetString(0);
                    }
                }
                return email;
            }
            catch (Exception exception)
            {
                Log.Error("Communication error with the database in GetEmail", exception);
                throw;
            }
        }

        public void DeleteReservation(string reservationId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashReservationsConnection))
                {
                    connection.Open();
                    StringBuilder stringBuilder = new StringBuilder();
                    SqlCommand command = new SqlCommand(stringBuilder.AppendFormat(SqlQueries.DeleteReservation, reservationId).ToString(), connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                Log.Error("Communication error with the database in DeleteReservation", exception);
                throw;
            }
        }

        public StatusEnum GetReservationStatus(string reservationId)
        {
            try
            {
                StatusEnum status = 0;
                using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashReservationsConnection))
                {
                    connection.Open();
                    StringBuilder stringBuilder = new StringBuilder();
                    using (SqlCommand command = new SqlCommand(stringBuilder.AppendFormat(SqlQueries.GetEmail, reservationId).ToString(), connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        status = (StatusEnum)reader.GetInt32(0);
                    }
                }
                return status;
            }
            catch (Exception exception)
            {
                Log.Error("Communication error with the database in GetReservationStatus", exception);
                throw;
            }
        }
    }
}