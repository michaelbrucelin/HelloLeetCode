using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0005
{
    public class Solution0005 : Interface0005
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MaxProduct(string[] words)
        {
            int result = 0, len = words.Length;
            int[] masks = new int[len];
            for (int i = 0; i < len; i++) for (int j = 0; j < words[i].Length; j++)
                {
                    masks[i] |= 1 << (words[i][j] - 'a');
                }

            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++)
                {
                    if ((masks[i] & masks[j]) == 0) result = Math.Max(result, words[i].Length * words[j].Length);
                }

            return result;
        }
    }
}
