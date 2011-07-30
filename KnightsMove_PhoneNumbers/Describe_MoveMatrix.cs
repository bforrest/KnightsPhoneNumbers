using System.Collections.Generic;
using NSpec;

namespace KnightsMove_PhoneNumbers
{
    public class Describe_MoveMatrix : nspec
    {
        private MoveMatrix matrix;

        public void given_a_move_matrix()
        {
            before = () => matrix = new MoveMatrix();

            context["starting from key 1"] = () =>
                {

                    List<int> answer = null;

                    before = () =>
                                {
                                    answer = matrix.ReachableFrom(1);
                                };

                    specify = () => answer.should_contain(6);

                    specify = () => answer.should_contain(8);
                };
            context["starting from key 5"] = () =>
                                                 {
                                                     List<int> answer = null;
                                                     before = () =>
                                                                  {
                                                                      answer = matrix.ReachableFrom(5);
                                                                  };
                                                     specify = () => answer.Count.should_be(0);
                                                 };
        }
    }
}