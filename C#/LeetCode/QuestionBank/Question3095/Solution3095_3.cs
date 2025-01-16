using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3095
{
    public class Solution3095_3 : Interface3095
    {
        /// <summary>
        /// 滑动窗口
        /// 1. 记录k哪些位置是1
        /// 2. 记录窗口内所有元素各个位置1的数量
        /// 3. 从高位向低位比较窗口内与k的1的数量
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumSubarrayLength(int[] nums, int k)
        {
            if (k == 0) return 1;

            int result = int.MaxValue, len = nums.Length, pl = 0, pr = -1;
            int[] kcnt = new int[7], wcnt = new int[7];                     // 题目限定的数据范围，int[7] 就够用
            for (int i = 0; i < 7; i++) kcnt[i] = (k >> i) & 1;
            while (++pr < len)
            {
                if (nums[pr] >= k) return 1;
                for (int i = 0; i < 7; i++) wcnt[i] += (nums[pr] >> i) & 1;
                while (Check())
                {
                    result = Math.Min(result, pr - pl + 1);
                    for (int i = 0; i < 7; i++) wcnt[i] -= (nums[pl] >> i) & 1;
                    pl++;
                }
            }

            return result == int.MaxValue ? -1 : result;

            bool Check()
            {
                bool result = true;
                for (int i = 6; i >= 0; i--) if (wcnt[i] != kcnt[i])
                    {
                        if (kcnt[i] == 0) break; else if (wcnt[i] > 0) continue;
                        result = false;
                        break;
                    }

                return result;
            }
        }
    }
}
