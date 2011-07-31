using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsMove_PhoneNumbers
{
    public class KeyPad
    {
        private readonly MoveMatrix _moveMatrix;
        private readonly List<Key> buttons;

        public KeyPad(MoveMatrix moveMatrix)
        {
            _moveMatrix = moveMatrix;
            buttons = new List<Key>(12);

            for (int row = 0; row < 4; row++) 
            {
                for (int column = 0; column < 3; column++)
                {
                    buttons.Add(new Key( buttons.Count + 1));
                }
            }
        }

        public IList<Key> Keys
        {
            get { return buttons; }
        }

        public List<PhoneNumber> GetNumbersStartingFrom(int startDigit)
        {
            building = new HashSet<PhoneNumber>();

            if (!PhoneNumber.IsValidStartDigit(startDigit))
                return building.ToList();

            PhoneNumber number = new PhoneNumber();
            List<PhoneNumber> accruedNumbers = new List<PhoneNumber>();

            if (number.TryAdd(startDigit))
            {
                AddToDigitSequence(accruedNumbers, number);
            }

            return accruedNumbers.Where(c => c.DigitCount == 7).ToList();
        }

        private HashSet<PhoneNumber> building;

        private List<PhoneNumber> AddToDigitSequence(List<PhoneNumber> aggregate, PhoneNumber sourceNumber)
        {
            int lastDigit = sourceNumber.LastDigit;

            var nextDigits = _moveMatrix.ReachableFrom(lastDigit);

            foreach (var nextDigit in nextDigits)
            {
                var newNumber = sourceNumber.Clone();
                if( newNumber.TryAdd(nextDigit))
                {
                    aggregate.Add(newNumber);
                    AddToDigitSequence(aggregate, newNumber);
                }
            }
            return aggregate;
        }
    }
}