using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundaWash.Infra
{
    public class PinRand
    {
        public static int randomPin = new Random().Next(0, 100);
    }
}
