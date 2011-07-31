using System.Collections.Generic;
using System.Linq;

namespace KnightsMove_PhoneNumbers
{
    public class PhoneNumberGenerator
    {
        private MoveMatrix _moveMatrix;

        public PhoneNumberGenerator(MoveMatrix moves)
        {
            _moveMatrix = moves;
        }

        public List<PhoneNumber> GetNumbersStartingFrom(int startDigit)
        {
            List<PhoneNumber> accruedNumbers = new List<PhoneNumber>();

            if (!PhoneNumber.IsValidStartDigit(startDigit))
                return accruedNumbers.ToList();

            PhoneNumber number = new PhoneNumber();
            

            if (number.TryAdd(startDigit))
            {
                AddToDigitSequence(accruedNumbers, number);
            }

            return accruedNumbers.Where(c => c.DigitCount == 7).ToList();
        }

        private List<PhoneNumber> AddToDigitSequence(List<PhoneNumber> aggregate, PhoneNumber sourceNumber)
        {
            int lastDigit = sourceNumber.LastDigit;

            var nextDigits = _moveMatrix.ReachableFrom(lastDigit);

            foreach (var nextDigit in nextDigits)
            {
                var newNumber = sourceNumber.Clone();
                if (newNumber.TryAdd(nextDigit))
                {
                    aggregate.Add(newNumber);
                    AddToDigitSequence(aggregate, newNumber);
                }
            }
            return aggregate;
        }
    }
}
