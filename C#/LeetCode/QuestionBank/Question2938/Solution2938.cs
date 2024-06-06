using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2938
{
    public class Solution2938 : Interface2938
    {
        /// <summary>
        /// 数学
        /// 1. 一定有解
        /// 2. 每次只能前进一步
        /// 3. 综合上面两点，计算最终的位置与初始位置的距离和即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long MinimumSteps(string s)
        {
            long cur = 0, cnt = 0, len = s.Length;  // cur是白球当前的位置
            for (int i = 0; i < len; i++)
            {
                cur += ('1' - s[i]) * i; cnt += '1' - s[i];
            }

            return cur - (cnt * (cnt - 1) >> 1);
        }
    }
}
