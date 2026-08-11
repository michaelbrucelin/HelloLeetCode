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
            int len = nums.Length, result = nums[0];
            for (int i = 1; i < len && nums[i] == nums[i - 1] + 1; i++) result += nums[i];

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
            int len = nums.Length, result = nums[0];
            for (int i = 1; i < len && nums[i] == nums[i - 1] + 1; i++) result += nums[i];

            bool[] set = new bool[51];
            for (int i = 0; i < len; i++) set[nums[i]] = true;
            while (result < set.Length && set[result]) result++;

            return result;
        }
    }
}
