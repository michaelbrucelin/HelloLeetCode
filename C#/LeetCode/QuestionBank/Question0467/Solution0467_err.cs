using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0467
{
    public class Solution0467_err : Interface0467
    {
        /// <summary>
        /// 遍历
        /// 找到zabc，就有4*(4+1)/2个
        /// 
        /// 审错题了，题目要的是去重复后的数量
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int FindSubstringInWraproundString(string s)
        {
            int result = 0, p1 = 0, p2, len = s.Length;
            while (p1 < len)
            {
                p2 = p1;
                while (p2 + 1 < len && (s[p2 + 1] - s[p1] == 1 || s[p2 + 1] - s[p1] == -25)) p2++;
                result += ((p2 - p1 + 2) * (p2 - p1 + 1)) >> 1;
                p1 = p2 + 1;
            }

            return result;
        }
    }
}
