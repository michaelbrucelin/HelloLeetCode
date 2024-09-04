using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2860
{
    public class Solution2860 : Interface2860
    {
        /// <summary>
        /// 排序
        /// 假定选择了cnt的，显然 最大选择项 < cnt < 最小未选择项
        /// 所以，将数组排序，最大选择项 与 最小未选择项 一定是相邻的，那么遍历即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountWays(IList<int> nums)
        {
            int[] _nums = nums.ToArray();
            Array.Sort(_nums);

            int result = 0;
            if (_nums[0] > 0) result++;
            if (_nums[^1] < _nums.Length) result++;
            for (int i = 1; i < _nums.Length; i++)
                if (_nums[i - 1] < i && _nums[i] > i) result++;

            return result;
        }

        public int CountWays2(IList<int> nums)
        {
            ((List<int>)nums).Sort();

            int result = 0;
            if (nums[0] > 0) result++;
            if (nums[^1] < nums.Count) result++;
            for (int i = 1; i < nums.Count; i++)
                if (nums[i - 1] < i && nums[i] > i) result++;

            return result;
        }
    }
}
