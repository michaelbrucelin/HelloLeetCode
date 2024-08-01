using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0128
{
    public class Solution0128 : Interface0128
    {
        /// <summary>
        /// 去重 + 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;

            HashSet<int> set = new HashSet<int>(nums);
            int[] _nums = set.ToArray();
            Array.Sort(_nums);

            int result = 1, _result = 1;
            for (int i = 1; i < _nums.Length; i++)
            {
                if (_nums[i] == _nums[i - 1] + 1)
                {
                    _result++;
                }
                else
                {
                    result = Math.Max(result, _result);
                    _result = 1;
                }
            }
            result = Math.Max(result, _result);

            return result;
        }
    }
}
