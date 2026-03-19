using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0451
{
    public class Solution0451 : Interface0451
    {
        /// <summary>
        /// 计数 + 构造
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FrequencySort(string s)
        {
            int len = s.Length;
            int[] cnts = new int[128];
            for (int i = 0; i < len; i++) cnts[s[i]]++;
            char[] chars = new char[128];
            for (int i = 0; i < 128; i++) chars[i] = (char)i;
            Array.Sort(chars, (x, y) => cnts[y] - cnts[x]);

            char[] result = new char[len];
            for (int i = 0, idx = 0, cnt; i < 128; i++) if ((cnt = cnts[chars[i]]) > 0) for (int j = 0; j < cnt; j++)
                    {
                        result[idx++] = chars[i];
                    }

            return new string(result);
        }
    }
}
