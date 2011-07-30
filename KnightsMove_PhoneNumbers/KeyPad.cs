using System.Collections.Generic;

namespace KnightsMove_PhoneNumbers
{
    public class KeyPad
    {
        private readonly List<Key> buttons;

        public KeyPad()
        {
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
            get { return this.buttons; }
        }
    }
}