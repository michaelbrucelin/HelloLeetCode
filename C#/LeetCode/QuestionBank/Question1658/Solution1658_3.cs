using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1658
{
    public class Solution1658_3 : Interface1658
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums, int x)
        {
            int sum = 0, len = nums.Length;
            for (int i = 0; i < len; i++) sum += nums[i];
            if (sum < x) return -1;
            if (sum == x) return len;

            int result = len, target = sum - x, pl = 0, pr = -1; sum = 0;
            while (pr < len && pl < len)
            {
                while (sum < target && ++pr < len) sum += nums[pr];
                if (sum == target) result = Math.Min(result, len - pr + pl - 1);
                while (pl < len && (sum -= nums[pl++]) > target) ;
            }

            return result != len ? result : -1;
        }
    }
}
