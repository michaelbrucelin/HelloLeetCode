using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2134
{
    public class Solution2134 : Interface2134
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSwaps(int[] nums)
        {
            int result = nums.Length, cnt = 0, len = nums.Length;
            for (int i = 0; i < len; i++) cnt += nums[i];
            if (cnt == 0 || cnt == len || cnt == len - 1) return 0;

            int _cnt = 0;
            for (int i = 0; i < cnt; i++) _cnt += nums[i];
            if ((result = Math.Min(result, cnt - _cnt)) == 0) return 0;
            for (int i = cnt; i < len; i++)
            {
                _cnt += nums[i] - nums[i - cnt];
                if ((result = Math.Min(result, cnt - _cnt)) == 0) return 0;
            }
            for (int i = 0, j = len - cnt + 1; j < len; i++, j++)
            {
                _cnt += nums[i] - nums[j - 1];
                if ((result = Math.Min(result, cnt - _cnt)) == 0) return 0;
            }

            return result;
        }
    }
}
