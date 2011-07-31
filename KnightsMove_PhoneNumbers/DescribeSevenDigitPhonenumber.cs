using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;

namespace KnightsMove_PhoneNumbers
{
    public class DescribeSevenDigitPhonenumber : nspec
    {
        private PhoneNumber phoneNumber;

        public void given_a_seven_digit_number()
        {
            before = () => phoneNumber = new PhoneNumber();

            context["Start number can not be zero or one"] = () =>
                    {
                        specify = () => phoneNumber.TryAdd(0).should_be_false();
                    
                        specify = () => phoneNumber.TryAdd(1).should_be_false();
                    };
            context["Try add returns false for invalid keys"] = () =>
                {
                    specify = () => phoneNumber.TryAdd(-1).should_be_false();
                };

            context["When Adding a second number"] = () =>
                {
                    before = () => phoneNumber.TryAdd(3).should_be_true();

                    specify = () => phoneNumber.TryAdd(-1).should_be_false();

                    specify = () => phoneNumber.TryAdd(0).should_be_true();

                    specify = () => phoneNumber.TryAdd(1).should_be_true();
                };
            context["Given a filled number"] = () =>
                {
                    before = () =>
                                {
                                    int number = 9;
                                    while (phoneNumber.DigitCount < 7)
                                    {
                                        phoneNumber.TryAdd(number);
                                        number--;
                                    }
                                };
                    specify = () => phoneNumber.DigitCount.should_be(7);

                    Console.WriteLine("Composed phone number: " + phoneNumber);

                    context["Can not add an eigth number"] = () =>
                        {
                            specify = () => phoneNumber.TryAdd(2).should_be_false();
                           
                        };
                    
                };
        }
    }

    public class DescribeMoveFor_Digit_2 : nspec
    {
        private KeyPad keyPad;

        public void given_the_2_key()
        {
            Key the2Key = null;

            before = () =>
                         {
                             keyPad = new KeyPad(new MoveMatrix());
                             the2Key = keyPad.Keys[1];
                         };
        }
    }

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
            clone.digitsThatMakeUpThisPhoneNumber.AddRange(this.digitsThatMakeUpThisPhoneNumber);
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