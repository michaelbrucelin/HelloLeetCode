using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3349
{
    public class Solution3349 : Interface3349
    {
        /// <summary>
        /// 遍历
        /// 遍历查找所有递增区间，找到长度 >= 2k 的区间 或 连续两个长度 >= k 的区间
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool HasIncreasingSubarrays(IList<int> nums, int k)
        {
            if (k == 1) return true;

            int l1 = 0, r1 = 0, l2 = 0, r2 = 0, cnt = nums.Count;
            for (int i = 1; i < cnt; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    r2 = i;
                }
                else
                {
                    if (i - l2 >= (k << 1)) return true;
                    if (i - l2 >= k && r1 - l1 + 1 >= k) return true;
                    l1 = l2; r1 = r2; l2 = i;
                }
            }
            if (r2 - l2 + 1 >= (k << 1)) return true;
            if (r2 - l2 + 1 >= k && r1 - l1 + 1 >= k) return true;

            return false;
        }
    }
}
