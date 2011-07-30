using System.Linq;
using NSpec;

namespace KnightsMove_PhoneNumbers
{
    public class DescribePhoneKeyPad : nspec
    {
        private KeyPad keyPad;
        
        public void given_standard_phone_keypad()
        {
            before = () => keyPad = new KeyPad();

            specify = () => keyPad.Keys.Count().should_be(12);

            context["key at index 0 should have coordinate 0,0 and value of 1"] = () =>
            {
                Key target = null;

                before = () => target = keyPad.Keys[0];

                specify = () => target.NumericValue.HasValue.is_true();

                specify = () => target.NumericValue.Is(1);

                specify = () => target.Coordinate.Row.Is(0);

                specify = () => target.Coordinate.Column.Is(0);

            };

            context["key at index 9 should have coordinate"] = () =>
            {
                Key target = null;

                before = () => target = keyPad.Keys[9];

                specify = () => target.NumericValue.HasValue.is_false();

                specify = () => target.Display.should_be("*");

                specify = () => target.Coordinate.Column.Is(0);

                specify = () => target.Coordinate.Row.Is(3);
            };


            context["key at index 11 should have coordinate"] = () =>
            {
                Key target = null;

                before = () => target = keyPad.Keys[11];

                specify = () => target.NumericValue.HasValue.is_false();

                specify = () => target.Display.should_be("#");

                specify = () => target.Coordinate.Column.Is(2);

                specify = () => target.Coordinate.Row.Is(3);
            };

            context["key at index 10 should have coordinate"] = () =>
            {
                Key target = null;

                before = () => target = keyPad.Keys[10];

                specify = () => target.NumericValue.HasValue.is_true();

                specify = () => target.NumericValue.should_be(0);

                specify = () => target.Coordinate.Column.Is(1);

                specify = () => target.Coordinate.Row.Is(3);
            };
        }
    }
}