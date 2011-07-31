using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsMove_PhoneNumbers
{
    public class PhoneNumber
    {
        private readonly List<int> digitsThatMakeUpThisPhoneNumber;

        public PhoneNumber()
        {
            digitsThatMakeUpThisPhoneNumber = new List<int>(7);
        }

        public PhoneNumber Clone()
        {
            var clone = new PhoneNumber();
            clone.digitsThatMakeUpThisPhoneNumber.AddRange(digitsThatMakeUpThisPhoneNumber);
            return clone;
        }

        public int DigitCount { get { return digitsThatMakeUpThisPhoneNumber.Count; } }

        public int LastDigit
        {
            get { return digitsThatMakeUpThisPhoneNumber.LastOrDefault(); }
        }

        public bool TryAdd(int valueToTry)
        {
            if(digitsThatMakeUpThisPhoneNumber.Count == 0 && !IsValidStartDigit(valueToTry)) 
                return false;

            if (valueToTry < 0)
            {
                return false;
            }
            
            if (digitsThatMakeUpThisPhoneNumber.Count == 7)
            {
                return false;
            }

            digitsThatMakeUpThisPhoneNumber.Add(valueToTry);
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(digitsThatMakeUpThisPhoneNumber.Count);

            foreach (var key in digitsThatMakeUpThisPhoneNumber)
            {
                sb.Append(key);
            }

            if (sb.Length == 7)
                sb.Insert(3, "-");

            return sb.ToString();
        }

        public static bool IsValidStartDigit(int testValue)
        {
            switch (testValue)
            {
                case 0:
                case 1:
                    return false;
            }
            return true;
        }
    }
}