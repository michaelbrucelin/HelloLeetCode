using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3838
{
    public class Solution3838 : Interface3838
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="words"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        public string MapWordWeights(string[] words, int[] weights)
        {
            int len = words.Length;
            char[] result = new char[len];
            for (int i = 0,w; i < len; i++)
            {
                w = 0;
                foreach (char c in words[i]) w += weights[c - 'a'];
                w %= 26;
                result[i] = (char)(25 - w + 'a');
            }

            return new string(result);
        }
    }
}
