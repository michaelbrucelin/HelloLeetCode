using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0522
{
    public class Solution0522 : Interface0522
    {
        /// <summary>
        /// 排序
        /// 首先，结果一定是整个字符串，如果是字符串的一部分，那么让这一部分更长一定还是结果，矛盾。
        /// 按照 [字符串长度降序, 字典序升序] 将 strs 排序，从前向后遍历，如果字符串唯一且不是前面任意一个字符串的子序列，那么这个字符串就是结果
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int FindLUSlength(string[] strs)
        {
            Comparer<string> comparer = Comparer<string>.Create((s1, s2) => (s2.Length - s1.Length) switch
            {
                > 0 => 1,
                < 0 => -1,
                _ => string.Compare(s1, s2, StringComparison.Ordinal)
            });
            Array.Sort(strs, comparer);
            if (strs[0] != strs[1]) return strs[0].Length;

            int ptr = 0, len = strs.Length;
            while (++ptr < len - 1) if (strs[ptr] != strs[ptr + 1])
                {
                    for (int i = 0; i < ptr; i++) if (IsLUS(strs[i], strs[ptr])) goto CONTINUE;
                    return strs[ptr].Length;
                    CONTINUE:;
                }
            for (int i = 0; i < len - 1; i++) if (IsLUS(strs[i], strs[^1])) goto END;
            return strs[^1].Length;
            END:;

            return -1;
        }

        private bool IsLUS(string str1, string str2)
        {
            if (str2.Length > str1.Length) return false;

            int p1 = 0, p2 = 0, l1 = str1.Length, l2 = str2.Length;
            while (p1 < l1 && p2 < l2)
            {
                if (str1[p1] == str2[p2]) p2++;
                p1++;
            }

            return p2 == l2;
        }
    }
}
