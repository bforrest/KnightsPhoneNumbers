using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace KnightsMove_PhoneNumbers
{
    [TestFixture]
    public class KeyPadDriver
    {
        private KeyPad keyPad;

        [SetUp]
        public void Setup()
        {
            keyPad = new KeyPad(new MoveMatrix());
        }

        [Test]
        public void no_numbers_start_with_zero()
        {
            var results = keyPad.GetNumbersStartingFrom(0);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void no_numbers_start_with_one()
        {
            var results = keyPad.GetNumbersStartingFrom(1);

            Assert.AreEqual(0, results.Count);
        }


        [Test]
        public void nothing_starts_with_5()
        {
            var results = keyPad.GetNumbersStartingFrom(5);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void can_we_find_numbers_starting_with_two()
        {
            var results = keyPad.GetNumbersStartingFrom(2);

            Assert.IsTrue(results.Count > 0);
        }

        [Test]
        public void can_get_a_seven_digit_number()
        {
            List<PhoneNumber> tehNumbersFromTehCodez = new List<PhoneNumber>();

            for (int i = 2; i < 10; i++)
            {
                var results = keyPad.GetNumbersStartingFrom(i);
                tehNumbersFromTehCodez.AddRange(results);
            }

            Console.WriteLine("We found {0} phone numbers", tehNumbersFromTehCodez.Count);
            Console.WriteLine("How many are distinct? {0}", tehNumbersFromTehCodez.Distinct().Count());

            var containsAFive = tehNumbersFromTehCodez.Find(c => c.ToString().Contains("5"));
            Assert.IsNull(containsAFive);

            foreach (var phoneNumber in tehNumbersFromTehCodez)
            {
                Console.WriteLine(phoneNumber);
            }
        }
    }
}