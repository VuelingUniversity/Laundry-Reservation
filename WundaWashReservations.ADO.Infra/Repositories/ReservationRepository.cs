using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private readonly string WundaWashReservationsConnection = ConfigurationManager.AppSettings["WundaWashReservationsConnection"];

        public bool SaveReservation(Reservation reservation)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(WundaWashReservationsConnection))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SqlQueries.SaveReservation, connection))
                    {
                        command.Parameters.AddWithValue("@Id", reservation.Id);
                        command.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
                        command.Parameters.AddWithValue("@MachineId", reservation.MachineId);
                        command.Parameters.AddWithValue("@Pin", reservation.Pin);
                        command.Parameters.AddWithValue("@PhoneNumber", reservation.PhoneNumber);
                        command.Parameters.AddWithValue("@Email", reservation.Email);
                        command.Parameters.AddWithValue("@Status", (int)reservation.Status);
                        int rows = command.ExecuteNonQuery();
                        return rows > 0 ? true : false;
                    }
                }
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
                using (SqlConnection connection = new SqlConnection(WundaWashReservationsConnection))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SqlQueries.UpdateReservationStatus, connection))
                    {
                        command.Parameters.AddWithValue("@Id", reservationId);
                        command.Parameters.AddWithValue("@Status", (int)status);
                        int rows = command.ExecuteNonQuery();
                        return rows > 0 ? true : false;
                    }
                }
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
                using (SqlConnection connection = new SqlConnection(WundaWashReservationsConnection))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SqlQueries.GetReservationIdByPin, connection))
                    {
                        command.Parameters.AddWithValue("@MachineId", machineId);
                        command.Parameters.AddWithValue("@Pin", pin);
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return reader.GetString(0);
                    }
                }
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
                using (SqlConnection connection = new SqlConnection(WundaWashReservationsConnection))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SqlQueries.GetMachineId, connection))
                    {
                        command.Parameters.AddWithValue("@Id", reservationId);
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                }
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
                using (SqlConnection connection = new SqlConnection(WundaWashReservationsConnection))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SqlQueries.GetEmail, connection))
                    {
                        command.Parameters.AddWithValue("@Id", reservationId);
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return reader.GetString(0);
                    }
                }
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
                using (SqlConnection connection = new SqlConnection(WundaWashReservationsConnection))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SqlQueries.DeleteReservation, connection))
                    {
                        command.Parameters.AddWithValue("@Id", reservationId);
                        command.ExecuteNonQuery();
                    };
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
                using (SqlConnection connection = new SqlConnection(WundaWashReservationsConnection))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SqlQueries.GetEmail, connection))
                    {
                        command.Parameters.AddWithValue("@Id", reservationId);
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return (StatusEnum)reader.GetInt32(0);
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error("Communication error with the database in GetReservationStatus", exception);
                throw;
            }
        }
    }
}