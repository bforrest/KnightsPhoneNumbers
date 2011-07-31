using System;
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
}