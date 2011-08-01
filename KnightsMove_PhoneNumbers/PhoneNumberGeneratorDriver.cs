using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace KnightsMove_PhoneNumbers
{
    [TestFixture]
    public class PhoneNumberGeneratorDriver
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            numberGenerator = new PhoneNumberGenerator(new GoofysMatrix());
        }

        #endregion

        private PhoneNumberGenerator numberGenerator;

        [Test]
        public void can_get_a_seven_digit_number()
        {
            var tehNumbersFromTehCodez = new List<PhoneNumber>();

            for (int i = 2; i < 10; i++)
            {
                List<PhoneNumber> results = numberGenerator.GetNumbersStartingFrom(i);
                tehNumbersFromTehCodez.AddRange(results);
            }

            Console.WriteLine("We found {0} phone numbers", tehNumbersFromTehCodez.Count);
            Console.WriteLine("How many are distinct? {0}", tehNumbersFromTehCodez.Distinct().Count());

            PhoneNumber containsAFive = tehNumbersFromTehCodez.Find(c => c.ToString().Contains("5"));
            Assert.IsNull(containsAFive);

            foreach (PhoneNumber phoneNumber in tehNumbersFromTehCodez)
            {
                Console.WriteLine(phoneNumber);
            }
        }

        [Test]
        public void can_we_find_numbers_starting_with_two()
        {
            List<PhoneNumber> results = numberGenerator.GetNumbersStartingFrom(2);

            Assert.IsTrue(results.Count > 0);
        }

        [Test]
        public void no_numbers_start_with_one()
        {
            List<PhoneNumber> results = numberGenerator.GetNumbersStartingFrom(1);

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void no_numbers_start_with_zero()
        {
            List<PhoneNumber> results = numberGenerator.GetNumbersStartingFrom(0);

            Assert.AreEqual(0, results.Count);
        }


        [Test]
        public void nothing_starts_with_5()
        {
            List<PhoneNumber> results = numberGenerator.GetNumbersStartingFrom(5);

            Assert.AreEqual(0, results.Count);
        }
    }
}