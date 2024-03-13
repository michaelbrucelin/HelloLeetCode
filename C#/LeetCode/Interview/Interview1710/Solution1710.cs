using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1710
{
    public class Solution1710 : Interface1710
    {
        /// <summary>
        /// XX投票
        /// 记不住算法名称了，相同元素，计数+1，不同元素，计数减1
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int maj = 0, cnt = 0, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                if (cnt != 0)
                {
                    cnt += nums[i] == maj ? 1 : -1;
                }
                else
                {
                    maj = nums[i]; cnt = 1;
                }
            }

            if (cnt == 0) return -1;
            cnt = 0;
            for (int i = 0; i < len; i++) if (nums[i] == maj) cnt++;

            return cnt > (len >> 1) ? maj : -1;
        }
    }
}
