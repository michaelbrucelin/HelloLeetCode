using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0942
{
    public class Solution0942 : Interface0942
    {
        /// <summary>
        /// 贪心
        /// 1. 令 pmin = 0, pmax = n
        /// 2. 如果 I，就取pmin，pmin++；如果 D，就取pmax，pmax--
        /// 3. 最后将剩下的唯一元素pmin==pmax加入结果
        /// 简要证明：
        /// 如果I，取pmin，无论后面的元素怎么取，都能保证是 I
        /// 如果D，取pmax，无论后面的元素怎么取，都能保证是 D
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] DiStringMatch(string s)
        {
            int len = s.Length, pmin = 0, pmax = len;
            int[] result = new int[len + 1];
            for (int i = 0; i < len; i++)
            {
                switch (s[i])
                {
                    case 'I': result[i] = pmin++; break;
                    case 'D': result[i] = pmax--; break;
                    default: break;
                }
            }
            result[len] = pmin;

            return result;
        }
    }
}
