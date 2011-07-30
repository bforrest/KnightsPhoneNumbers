using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsMove_PhoneNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            PhoneNumber phoneNumber = new PhoneNumber();

            int number = 9;
            while (phoneNumber.DigitCount < 7)
            {
                phoneNumber.TryAdd(new Key(number, null));
                number--;
            }

            Console.WriteLine(phoneNumber);
        }

    }
}
