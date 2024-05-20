using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1542
{
    public class Solution1542_3 : Interface1542
    {
        /// <summary>
        /// 遍历
        /// 本质上同Solution1542，分析一下为什么Solution1542会那么慢
        ///     原因在于计算以s[n+1]结尾的字串时的时间复杂度为O(n)
        /// 所以，如果优化了这一步就会更快，而使用mask比较时，至多有1024种状态，记录每一种状态第一次出现的位置即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestAwesome(string s)
        {
            if (s.Length < 2) return 1;

            int[] masks = new int[1024];
            Array.Fill(masks, -2); masks[0] = -1;

            int result = 1, mask = 0, toggle, len = s.Length;
            for (int i = 0; i < len; i++)
            {
                mask ^= 1 << (s[i] & 15);
                if (masks[mask] != -2) result = Math.Max(result, i - masks[mask]); else masks[mask] = i;
                for (int j = 0; j < 10; j++)
                {
                    toggle = mask ^ (1 << j);
                    if (masks[toggle] != -2) result = Math.Max(result, i - masks[toggle]);
                }
            }

            return result;
        }
    }
}
