using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0128
{
    public class Solution0128_off : Interface0128
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;

            int result = 0, _result, _num;
            HashSet<int> set = new HashSet<int>(nums);
            foreach (int num in set) if (!set.Contains(num - 1))
                {
                    _result = 1;
                    _num = num;
                    while (set.Contains(++_num)) _result++;
                    result = Math.Max(result, _result);
                }

            return result;
        }
    }
}
