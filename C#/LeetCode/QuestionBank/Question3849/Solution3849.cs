using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3849
{
    public class Solution3849 : Interface3849
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MaximumXor(string s, string t)
        {
            int len = t.Length;
            int[] cnts = new int[2];
            for (int i = 0; i < len; i++) cnts[t[i] & 1]++;

            char[] result = new char[len];
            for (int i = 0, idx; i < len; i++)
            {
                idx = s[i] & 1 ^ 1;
                if (cnts[idx] > 0)
                {
                    result[i] = '1'; cnts[idx]--;
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; i <= cnts[0]; i++) result[len - i] = s[len - i];
            int SUM = '0' + '1';
            for (int i = 1; i <= cnts[1]; i++) result[len - i] = (char)(SUM - s[len - i]);

            return new string(result);
        }
    }
}
