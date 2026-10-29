using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2384
{
    public class Solution2384 : Interface2384
    {
        /// <summary>
        /// 贪心构造
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string LargestPalindromic(string num)
        {
            if (num.Length < 2) return num;

            int[] cnts = new int[10];
            foreach (char c in num) cnts[c - '0']++;
            bool flag1 = true, flag2 = true;          // flag1表示num中只有0，flag2表示num中除了0其余数字最多只有1个
            for (int i = 1; i < 10; i++) if (cnts[i] > 1) { flag1 = flag2 = false; break; } else if (cnts[i] > 0) flag1 = false;
            if (flag1) return "0";
            if (flag2) for (int i = 9; i > 0; i--) if (cnts[i] != 0) return i.ToString();

            List<(int, int)> info = [];  // (char, int)
            int len = 0;
            for (int i = 9; i >= 0; i--) if (cnts[i] > 0)
                {
                    info.Add((i, cnts[i] >> 1));
                    len += cnts[i] - (cnts[i] & 1);
                    cnts[i] &= 1;
                }
            int mid = -1;
            for (int i = 9; i >= 0; i--) if (cnts[i] != 0) { mid = i; len++; break; }

            char[] result = new char[len];
            int pl = 0, pr = len - 1; char ch;
            foreach ((int chi, int cnt) in info) if (cnt > 0)
                {
                    ch = (char)(chi + '0');
                    for (int i = 0; i < cnt; i++) result[pl++] = result[pr--] = ch;
                }
            if (mid != -1) result[pl] = (char)(mid + '0');

            return new string(result);
        }
    }
}
