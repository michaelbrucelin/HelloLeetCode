using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1653
{
    public class Solution1653_2 : Interface1653
    {
        public int MinimumDeletions2(string s)
        {
            int cnta = 0, cntb = 0, len = s.Length;
            for (int i = 0; i < len; i++) if (s[i] == 'a') cnta++;

            int result = Math.Min(cnta, len - cnta);
            for (int i = 0; i < len - 1; i++)
            {
                if (s[i] == 'a') cnta--; else cntb++;
                result = Math.Min(result, cnta + cntb);
            }

            return result;
        }

        /// <summary>
        /// 与MinimumDeletions()一样，将if-else换成了映射，据说CPU执行映射比执行if-else更快
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimumDeletions(string s)
        {
            int cnta = 0, cntb = 0, len = s.Length;
            for (int i = 0; i < len; i++) cnta += 'b' - s[i];  // if (s[i] == 'a') cnta++;

            int result = Math.Min(cnta, len - cnta);
            for (int i = 0, _result = cnta; i < len - 1; i++)
            {
                // if (s[i] == 'a') cnta--; else cntb++; 即'a'步数-1，'b'步数+1
                _result += ((s[i] - 'a') << 1) - 1;
                result = Math.Min(result, _result);
            }

            return result;
        }
    }
}
