using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0556
{
    public class Solution0556 : Interface0556
    {
        /// <summary>
        /// 下一个更大的字符串
        /// 逻辑同下一个更大的字符串，处理好溢出就行
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NextGreaterElement(int n)
        {
            if (n < 12) return -1;

            char[] chars = [.. n.ToString()];
            int p1 = chars.Length, len = chars.Length;
            while (--p1 > 0 && chars[p1] <= chars[p1 - 1]) ;
            if (p1 == 0) return -1;
            int p2 = len; p1--;
            while (chars[--p2] <= chars[p1]) ;                // 可以二分，这里长度很小，没必要二分
            (chars[p1], chars[p2]) = (chars[p2], chars[p1]);
            p2 = len;
            while (++p1 < --p2) (chars[p1], chars[p2]) = (chars[p2], chars[p1]);

            long result = 0;
            for (int i = 0; i < len; i++) result = result * 10 + chars[i] - '0';
            return result <= int.MaxValue ? (int)result : -1;
        }
    }
}
