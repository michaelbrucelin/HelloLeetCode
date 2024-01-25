using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2996
{
    public class Solution2996 : Interface2996
    {
        public int MissingInteger(int[] nums)
        {
            int result = nums[0];
            for (int i = 1; i < nums.Length && nums[i] == nums[i - 1] + 1; i++)
                result += nums[i];

            HashSet<int> set = new HashSet<int>(nums);
            while (set.Contains(result)) result++;

            return result;
        }

        /// <summary>
        /// 逻辑与MissingInteger()一样，只是将Hash表改成了int[]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingInteger2(int[] nums)
        {
            int result = nums[0];
            for (int i = 1; i < nums.Length && nums[i] == nums[i - 1] + 1; i++)
                result += nums[i];

            bool[] set = new bool[51];
            for (int i = 0; i < nums.Length; i++) set[nums[i]] = true;
            while (result < set.Length && set[result]) result++;

            return result;
        }
    }
}
