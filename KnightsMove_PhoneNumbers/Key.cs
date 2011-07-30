namespace KnightsMove_PhoneNumbers
{
    public class Key
    {
        public Key(int keyId, Point location = null)
        {
            if (location != null) Coordinate = location;

            switch(keyId)
            {
                case 11:
                    NumericValue = 0;
                    break;
                case 10:
                    Display = "*";
                    break;
                case 12:
                    Display = "#";
                    break;
                default:
                    NumericValue = keyId;
                    break;
            }
        }

        public string Display { get; protected set; }

        public int? NumericValue { get; protected set; }

        public Point Coordinate { get; protected set; }

        public override string ToString()
        {
            return Display;
        }
    }
}