using System.Collections.Generic;
using System.Linq;

namespace KnightsMove_PhoneNumbers
{
    public class PhoneNumberGenerator
    {
        private readonly IMoveMatrix _moveMatrix;

        public PhoneNumberGenerator(IMoveMatrix moves)
        {
            _moveMatrix = moves;
        }

        public List<PhoneNumber> GetNumbersStartingFrom(int startDigit)
        {
            var accruedNumbers = new List<PhoneNumber>();

            if (!PhoneNumber.IsValidStartDigit(startDigit))
                return accruedNumbers.ToList();

            var number = new PhoneNumber();


            if (number.TryAdd(startDigit))
            {
                AddToDigitSequence(accruedNumbers, number);
            }

            return accruedNumbers.Where(c => c.DigitCount == 7).ToList();
        }

        private void AddToDigitSequence(List<PhoneNumber> aggregate, PhoneNumber sourceNumber)
        {
            int lastDigit = sourceNumber.LastDigit;

            List<int> nextDigits = _moveMatrix.ReachableFrom(lastDigit);

            foreach (int nextDigit in nextDigits)
            {
                PhoneNumber newNumber = sourceNumber.Clone();
                if (newNumber.TryAdd(nextDigit))
                {
                    aggregate.Add(newNumber);
                    AddToDigitSequence(aggregate, newNumber);
                }
            }
            return;
        }
    }
}