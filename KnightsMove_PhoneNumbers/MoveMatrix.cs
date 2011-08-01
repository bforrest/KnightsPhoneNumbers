using System.Collections.Generic;

namespace KnightsMove_PhoneNumbers
{
    public interface IMoveMatrix
    {
        List<int> ReachableFrom(int origin);
    }

    public class MoveMatrix : IMoveMatrix
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
                             {1, new List<int> {6, 8}},
                             {2, new List<int> {7, 9}},
                             {3, new List<int> {4, 8}},
                             {4, new List<int> {3, 9, 0}},
                             {6, new List<int> {1, 7, 0}},
                             {7, new List<int> {2, 6}},
                             {8, new List<int> {1, 3}},
                             {9, new List<int> {4, 2}},
                             {0, new List<int> {4, 6}}
                         };
        }

        #region IMoveMatrix Members

        public List<int> ReachableFrom(int origin)
        {
            return !matrix.ContainsKey(origin) ? new List<int>() : matrix[origin];
        }

        #endregion
    }

    public class GoofysMatrix : IMoveMatrix
    {
        private readonly Dictionary<int, List<int>> matrix;

        public GoofysMatrix()
        {
            matrix = new Dictionary<int, List<int>>
                         {
                             {1, new List<int> {6, 8}},
                             {2, new List<int> {7, 9}},
                             {3, new List<int> {4, 8}},
                             {4, new List<int> {3, 9}},
                             {6, new List<int> {1, 7}},
                             {7, new List<int> {2, 6}},
                             {8, new List<int> {1, 3}},
                             {9, new List<int> {4, 2}},
                             {0, new List<int> {4, 6}}
                         };
        }

        #region IMoveMatrix Members

        public List<int> ReachableFrom(int origin)
        {
            return !matrix.ContainsKey(origin) ? new List<int>() : matrix[origin];
        }

        #endregion
    }
}