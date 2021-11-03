using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWash.Infra.SqlComponents
{
    public class Queries
    {
        int PinRandom = PinRand.randomPin;
        public const string GetAllMachineUnlock = @"SELECT Id_machine,Model,Lock FROM MachineL WHERE Lock=0";
        public const string CheckMachineIsLock = @"SELECT Lock FROM MachineL WHERE Id_machine={0}";
        public const string InsertNewReservation = @"INSERT INTO Reservation (Id_patron,Id_machine,Pin,DateReservation
                VALUES()";
        public const string GetAllPatrons = @"SELECT * FROM Patron";

    }
}
