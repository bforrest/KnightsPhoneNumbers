using System.Collections.Generic;

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

    public class MoveMatrix
    {
        /*      Can Reach Numbers
         * 1    6   8
         * 2    7   9
         * 3    4   8
         * 4    3   9   0
         * 5    *   #
         * 6    1   7   0
         * 7    2   6   #
         * 8    1   3
         * 9    4   2   *
         * 0    4   6
         * *    -
         * #    -
         */

        private readonly Dictionary<int, List<int>> matrix;

        public MoveMatrix()
        {
            matrix = new Dictionary<int, List<int>>
                         {
                             {1, new List<int>(){6, 8}},
                             {2, new List<int>(){7,9}},
                             {3, new List<int>(){4,8}},
                             {4, new List<int>(){3,9,0}},
                             {6, new List<int>(){1,7,0}},
                             {7, new List<int>(){2,6}},
                             {8, new List<int>(){1,3}},
                             {9, new List<int>(){4,2}},
                             {0, new List<int>(){4,6}}
                         };
        }

        public List<int> ReachableFrom(int origin)
        {
            return !matrix.ContainsKey(origin) ? new List<int>() : matrix[origin];
        }
    }
}