using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2855
{
    public class Solution2855 : Interface2855
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumRightShifts(IList<int> nums)
        {
            if (nums.Count == 1) return 0;

            int p1 = 1, cnt = nums.Count;
            while (p1 < cnt && nums[p1] > nums[p1 - 1]) p1++;                        // 第一段递增区间
            if (p1 == cnt) return 0;
            if (nums[p1] > nums[0]) return -1;

            int p2 = p1 + 1;
            while (p2 < cnt && nums[p2] > nums[p2 - 1] && nums[p2] < nums[0]) p2++;  // 第二段递增区间

            return p2 == cnt ? cnt - p1 : -1;
        }
    }
}
