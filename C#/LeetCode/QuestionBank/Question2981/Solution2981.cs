using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2981
{
    public class Solution2981 : Interface2981
    {
        /// <summary>
        /// 双指针，记录，查找最大值
        /// 记录每一个字符，不同长度“特殊 字符串”的次数
        ///     N个x，长度为N 1次，长度为N-1 2次，长度为N-2 3次
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaximumLength(string s)
        {
            int[,] freq = new int[26, 51];   // 题目限定字符串长度最长50
            int pl = 0, pr, len = s.Length;
            while (pl < len)
            {
                pr = pl;
                while (pr + 1 < len && s[pr + 1] == s[pl]) pr++;
                freq[s[pl] - 'a', pr - pl + 1]++;
                if (pr - pl > 0) freq[s[pl] - 'a', pr - pl] += 2;
                if (pr - pl - 1 > 0) freq[s[pl] - 'a', pr - pl - 1] += 3;
                pl = pr + 1;
            }

            int result = -1;
            for (int i = 0; i < 26; i++) for (int j = 1; j < 50; j++)
                {
                    if (freq[i, j] >= 3) result = Math.Max(result, j);
                }

            return result;
        }
    }
}
