using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2009
{
    public class Solution2009_2 : Interface2009
    {
        /// <summary>
        /// 排序 + 双指针
        /// 逻辑同Solution2009，只是将原数组先去重复再排序遍历，如果数组中有大量重复值，这样更快
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            if (nums.Length == 1) return 0;
            int[] _nums = nums.Distinct().OrderBy(i => i).ToArray();
            if (_nums.Length == 1) return nums.Length - 1;

            int result = nums.Length, len = nums.Length, _len = _nums.Length, p1 = -1, p2 = 0;
            HashSet<int> cnts = new HashSet<int>() { _nums[0] };
            while (++p1 < _len)
            {
                if (p1 > 0) cnts.Remove(_nums[p1 - 1]);
                while (p2 + 1 < _len && _nums[p2 + 1] <= _nums[p1] + len - 1) cnts.Add(_nums[++p2]);
                result = Math.Min(result, len - cnts.Count);
            }

            return result;
        }
    }
}
