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

            context["Start number can not be zero, one or non-numeric"] = () =>
                    {
                        specify = () => phoneNumber.TryAdd(new Key(0, null)).should_be_false();
                    
                        specify = () => phoneNumber.TryAdd(new Key(1, null)).should_be_false();

                        specify = () => phoneNumber.TryAdd(new Key(10, null)).should_be_false();
                    };
            context["Try add returns false for invalid keys"] = () =>
                {
                    specify = () => phoneNumber.TryAdd(new Key(10, null)).should_be_false();
                };

            context["When Adding a second number"] = () =>
                {
                    before = () => phoneNumber.TryAdd(new Key(3, null)).should_be_true();

                    specify = () => phoneNumber.TryAdd(new Key(10, null)).should_be_false();

                    specify = () => phoneNumber.TryAdd(new Key(0, null)).should_be_true();

                    specify = () => phoneNumber.TryAdd(new Key(1, null)).should_be_true();
                };
            context["Given a filled number"] = () =>
                {
                    before = () =>
                                {
                                    int number = 9;
                                    while (phoneNumber.DigitCount < 7)
                                    {
                                        phoneNumber.TryAdd(new Key(number, null));
                                        number--;
                                    }
                                };
                    specify = () => phoneNumber.DigitCount.should_be(7);

                    Console.WriteLine("Composed phone number: " + phoneNumber);

                    context["Can not add an eigth number"] = () =>
                        {
                            specify = () => phoneNumber.TryAdd(new Key(2, null)).should_be_false();
                           
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
                             keyPad = new KeyPad();
                             the2Key = keyPad.Keys[1];
                         };
        }
    }

    public class PhoneNumber
    {
        private readonly List<Key> digitsThatMakeUpThisPhoneNumber;

        public PhoneNumber()
        {
            digitsThatMakeUpThisPhoneNumber = new List<Key>(7);
        }

        public int DigitCount { get { return digitsThatMakeUpThisPhoneNumber.Count; } }

        public string Display
        {
            get { return this.ToString(); }
        }

        public bool TryAdd(Key keyToTry)
        {
            if (!IsValidStartDigit(keyToTry)) return false;

            if (!keyToTry.NumericValue.HasValue)
            {
                return false;
            }
            
            if (digitsThatMakeUpThisPhoneNumber.Count == 7)
            {
                return false;
            }

            digitsThatMakeUpThisPhoneNumber.Add(keyToTry);
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(digitsThatMakeUpThisPhoneNumber.Count);

            foreach (var key in digitsThatMakeUpThisPhoneNumber)
            {
                sb.Append(key.NumericValue.Value);
            }

            if (sb.Length == 7)
                sb.Insert(3, "-");

            return sb.ToString();
        }
        private bool IsValidStartDigit(Key keyToTry)
        {
            if (digitsThatMakeUpThisPhoneNumber.Count == 0)
            {
                switch (keyToTry.NumericValue)
                {
                    case 0:
                    case 1:
                        return false;
                }
            }
            return true;
        }
    }
}