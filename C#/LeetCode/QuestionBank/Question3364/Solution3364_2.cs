using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3364
{
    public class Solution3364_2 : Interface3364
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public int MinimumSumSubarray(IList<int> nums, int l, int r)
        {
            int result = int.MaxValue, len = nums.Count;
            for (int win = l, _result; win <= r; win++)
            {
                _result = 0;
                for (int i = 0; i < win; i++) _result += nums[i];
                if (_result > 0) result = Math.Min(result, _result);
                for (int i = win; i < len; i++)
                {
                    _result += nums[i] - nums[i - win];
                    if (_result > 0) result = Math.Min(result, _result);
                }
            }

            return result != int.MaxValue ? result : -1;
        }
    }
}
