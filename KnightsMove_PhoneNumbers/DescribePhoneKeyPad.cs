using System.Collections.Generic;
using System.Linq;
using NSpec;

namespace KnightsMove_PhoneNumbers
{
    public class DescribePhoneKeyPad : nspec
    {
        private KeyPad keyPad;
        
        public void given_standard_phone_keypad()
        {
            before = () => keyPad = new KeyPad(new MoveMatrix());

            specify = () => keyPad.Keys.Count().should_be(12);

            context["key at index 0 should have coordinate 0,0 and value of 1"] = () =>
            {
                Key target = null;

                before = () => target = keyPad.Keys[0];

                specify = () => target.Id.should_be(1);
            };

            context["key at index 9 should have coordinate"] = () =>
            {
                Key target = null;

                before = () => target = keyPad.Keys[9];

                specify = () => target.Id.should_be(10);
            };


            context["key at index 11 should have coordinate"] = () =>
            {
                Key target = null;

                before = () => target = keyPad.Keys[11];

                specify = () => target.Id.should_be(12);
            };

            context["key at index 10 should Zero key"] = () =>
            {
                Key target = null;

                before = () => target = keyPad.Keys[10];

                specify = () => target.NumericValue.should_be(0);
            };
        }

        public void given_a_startomg_number()
        {
            before = () => keyPad = new KeyPad(new MoveMatrix());

            context["no valid phone numbers start with zero"] = () =>
            {
                List<PhoneNumber> listOfNumbers = keyPad.GetNumbersStartingFrom(0);

                specify = () => listOfNumbers.Count.should_be(0);
            };

            context["no valid numbers start with one"] = () =>
            {
                List<PhoneNumber> listOfNumbers = keyPad.GetNumbersStartingFrom(1);

                specify = () => listOfNumbers.Count.should_be(0);
            };

            context["starting from two (2) should produce valid numbers"] = () =>
            {
                List<PhoneNumber> listOfNumbers = keyPad.GetNumbersStartingFrom(2);

                specify = () => listOfNumbers.Count.should_be_greater_than(0);
            };
        }
    }
}