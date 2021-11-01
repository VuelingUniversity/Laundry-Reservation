using KataMachineAPI.Core.Models;
using KataMachineAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataMachineAPI.Console
{
    public class Program
    {
        private static void Main(string[] args)
        {
            ReservationRepository repo = new ReservationRepository(null);
            List<Reservation> list = repo.GetAll();

            foreach (var x in list)
            {
                System.Console.WriteLine($"{x.Id} - {x.EmailAdress}");
            }

            System.Console.WriteLine(repo.CreateReservation(new Reservation
            {
                ReservationDate = DateTime.Now,
                EmailAdress = "nachodeharo5@gmail.com",
                MachineNumber = 2,
                PIN = 12345
            }));
            System.Console.ReadLine();
        }
    }
}