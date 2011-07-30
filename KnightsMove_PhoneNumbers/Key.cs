namespace KnightsMove_PhoneNumbers
{
    public class Key
    {
        
        public Key(int keyId)
        {
            Id = keyId;

            switch(keyId)
            {
                case 11:
                    NumericValue = 0;
                    break;
                case 10:
                case 12:
                    // not valid numbers
                    break;
                default:
                    NumericValue = keyId;
                    break;
            }
        }

        public int Id { get; protected set; }

        public int? NumericValue { get; protected set; }

        public bool CanMoveTo(int targetNumber)
        {
            return false;
        }
    }
}