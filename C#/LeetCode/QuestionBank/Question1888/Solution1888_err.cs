using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1888
{
    public class Solution1888_err : Interface1888
    {
        /// <summary>
        /// 分析
        /// 1. 将 s 拆分为若干段“交错”的子串
        /// 2. 如果 s[0] 与 s[^1] 不同，第一段子串与最后一段子串理解为同一个子串（操作1）
        /// 3. 要么把 0 2 4... 段子串全部反转，要么把 1 3 5... 段子串全部反转，注意
        ///     如果反转 0 2 4...，且总共有奇数个子串时，最多可以有一个子串不需要反转（至少需要反转 1 组）
        ///     如果反转 1 3 5...，且总共有偶数个子串时，最多可以有一个子串不需要反转（至少需要反转 1 组）
        /// 
        /// 思路还是不对，不写了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinFlips(string s)
        {
            int len = s.Length;
            if (len <= 1) return 0;
            if (len == 2) return 1 - Math.Abs(s[0] - s[1]);

            List<int> lens = [];
            int pl = 0, pr;
            while (pl < len)
            {
                pr = pl;
                while (pr + 1 < len && s[pr + 1] != s[pr]) pr++;
                lens.Add(pr - pl + 1);
                pl = pr + 1;
            }
            int cnt = s[0] != s[^1] ? lens.Count : lens.Count - 1;
            if (cnt == 1) return 0;
            if (cnt <= 3) return Math.Min(lens[0], Math.Min(lens[1], lens[2]));

            int r1 = 0, r2 = 0, max;
            if (s[0] != s[^1]) { pl = 1; lens[^1] += lens[0]; } else pl = 0;
            // 反转 0 2 4 ...
            max = 0;
            for (int i = pl + 0; i < cnt; i += 2) r1 += lens[i];
            if ((cnt & 1) != (pl & 1)) r1 -= lens[^1];
            // 反转 1 3 5 ...
            for (int i = pl + 1; i < cnt; i += 2) r2 += lens[i];

            return Math.Min(r1, r2);
        }
    }
}
