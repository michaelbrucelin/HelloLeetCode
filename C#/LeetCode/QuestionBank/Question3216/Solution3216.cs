using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3216
{
    public class Solution3216 : Interface3216
    {
        /// <summary>
        /// 遍历
        /// 注意，比较两个数字字符是否具有相同的奇偶性与大小时，直接比较原值即可，不需要先转为数字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string GetSmallestString(string s)
        {
            int p = 0, len = s.Length;
            while (++p < len)
            {
                if (s[p] < s[p - 1] && (s[p] & 1) == (s[p - 1] & 1)) break;
            }
            if (p == len) return s;

            return $"{s[0..(p - 1)]}{s[p]}{s[p - 1]}{s[(p + 1)..]}";
        }
    }
}
