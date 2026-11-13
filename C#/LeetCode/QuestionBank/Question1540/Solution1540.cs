using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1540
{
    public class Solution1540 : Interface1540
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanConvertString(string s, string t, int k)
        {
            if (s.Length != t.Length) return false;

            int len = s.Length;
            List<int> offset = [];
            for (int i = 0; i < len; i++) if (s[i] != t[i]) offset.Add((t[i] - s[i] + 26) % 26);
            if (k < offset.Count) return false;
            if (k / 26 > offset.Count) return true;

            int[] move = new int[27];
            var info = Math.DivRem(k, 26);
            for (int i = 1; i < 27; i++) move[i] = info.Quotient;
            for (int i = 1; i <= info.Remainder; i++) move[i]++;
            for (int i = 0, cnt = offset.Count; i < cnt; i++)
            {
                if (move[offset[i]] == 0) return false;
                move[offset[i]]--;
            }

            return true;
        }
    }
}
