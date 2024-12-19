using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1431
{
    public class Solution1431 : Interface1431
    {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int max = candies[0], len = candies.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, candies[i]);

            bool[] result = new bool[len];
            for (int i = 0; i < len; i++) result[i] = candies[i] + extraCandies >= max;

            return result;
        }

        public IList<bool> KidsWithCandies2(int[] candies, int extraCandies)
        {
            int threshold = candies.Max() - extraCandies - 1, len = candies.Length;
            bool[] result = new bool[len];
            for (int i = 0; i < len; i++)
            {
                if (candies[i] > threshold) result[i] = true;
            }

            return result;
        }
    }
}
