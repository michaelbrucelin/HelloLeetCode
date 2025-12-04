using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3718
{
    public class Solution3718 : Interface3718
    {
        /// <summary>
        /// hash
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MissingMultiple(int[] nums, int k)
        {
            HashSet<int> set = [.. nums];
            int result = k;
            while (set.Contains(result)) result += k;

            return result;
        }

        public int MissingMultiple2(int[] nums, int k)
        {
            bool[] set = new bool[101];
            foreach (int num in nums) set[num] = true;
            int result = k;
            while (result < 101 && set[result]) result += k;

            return result;
        }
    }
}
