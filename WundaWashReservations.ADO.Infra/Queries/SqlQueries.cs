using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.ADO.Infra.Queries
{
    public static class SqlQueries
    {
        public const string SaveReservation = "INSERT INTO Reservation VALUES('{0}', '{1}', {2}, {3}, {4}, '{5}')";
    }
}