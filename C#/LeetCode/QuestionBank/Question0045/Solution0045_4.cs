using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0045
{
    public class Solution0045_4 : Interface0045
    {
        /// <summary>
        /// 贪心
        /// 逻辑同Solution0055_4，只是Solution0055_4中维护一个可达的最远距离，这里需要同时维护可达的最远距离和次远距离
        /// 类似于BFS的思路，也有滑动窗口的味道
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int result = 0, last = -1, curr = 0, next, len = nums.Length;
            while (curr < len)
            {
                result++; next = curr;
                for (int i = last + 1; i <= curr; i++)
                {
                    next = Math.Max(next, i + nums[i]);
                    if (next >= len - 1) return result;
                }
                last = curr; curr = next;
            }

            return result;
        }
    }
}
