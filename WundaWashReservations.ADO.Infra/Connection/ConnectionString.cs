using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWashReservations.ADO.Infra.Connection
{
    public static class ConnectionString
    {
        public static string WundaWashReservationsConnection = @"Data Source=(localdb)\WundaWash;Initial Catalog=WundaWashReservations;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}