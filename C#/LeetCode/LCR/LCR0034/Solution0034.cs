using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0034
{
    public class Solution0034 : Interface0034
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="words"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool IsAlienSorted(string[] words, string order)
        {
            int[] _order = new int[26];
            for (int i = 0; i < 26; i++) _order[order[i] - 'a'] = i;
            for (int i = 0, j = 1, k; j < words.Length; i++, j++)
            {
                k = 0; for (; k < words[i].Length && k < words[j].Length; k++)
                {
                    if (words[i][k] == words[j][k]) continue;
                    if (_order[words[i][k] - 'a'] < _order[words[j][k] - 'a']) goto CONTINUE;
                    if (_order[words[i][k] - 'a'] > _order[words[j][k] - 'a']) return false;
                }
                if (k != words[i].Length) return false;
                CONTINUE:;
            }

            return true;
        }
    }
}
