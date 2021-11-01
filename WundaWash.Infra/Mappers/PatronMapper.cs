using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Models;

namespace WundaWash.Infra.Mappers
{
    public class PatronMapper
    {
        public static Patron Map(SqlDataReader reader)
        {
            Patron patron = new Patron
            {
                Id_patron = reader.GetInt32(0),
                PhoneNumber = reader.GetInt32(1),
                Email = reader.GetString(2)
            };
            return patron;
        }
    }
}
