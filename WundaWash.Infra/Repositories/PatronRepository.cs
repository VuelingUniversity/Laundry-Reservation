using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundaWash.Core.Interfaces;
using WundaWash.Core.Models;
using WundaWash.Infra.Mappers;
using WundaWash.Infra.SqlComponents;
using WundaWash.ServiceLibrary.Interfaces;

namespace WundaWash.Infra.Repositories
{

    public class PatronRepository : IPatronRepository
    {
        public List<Patron> GetAllPatrons()
        {
            List<Patron> _patrons = new List<Patron>();
            using (SqlConnection connection = new SqlConnection(ConnectionString.WundaWashConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Queries.GetAllPatrons, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Patron patron = PatronMapper.Map(reader);
                        _patrons.Add(patron);
                    }
                }
            }
            return _patrons;
        }
    }
}
