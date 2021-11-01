using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWash.Infra.SqlComponents
{
    public class ConnectionString
    {
        public static string WundaWashConnection = @"Data Source=(localdb)\WundaWash;Initial Catalog=WundaWash;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
