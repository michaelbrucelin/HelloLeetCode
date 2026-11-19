using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4070
{
    public class Solution4070 : Interface4070
    {
        /// <summary>
        /// 预处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinRotations(string s)
        {
            int[,] cnts = new int[10, 10];
            for (int i = 0; i < 10; i++) for (int j = i + 1; j < 10; j++) cnts[i, j] = cnts[j, i] = Math.Min(j - i, i + 10 - j);

            int result = cnts[0, s[0] & 15], len = s.Length;
            for (int i = 1; i < len; i++) result += cnts[s[i - 1] & 15, s[i] & 15];

            return result;
        }
    }
}
