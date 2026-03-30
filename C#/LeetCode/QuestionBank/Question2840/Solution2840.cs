using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2840
{
    public class Solution2840 : Interface2840
    {
        /// <summary>
        /// 遍历
        /// 奇数位与偶数位的字符集相同即可
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckStrings(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            int len = s1.Length;
            int[,] cnts = new int[26, 2];
            for (int i = 0; i < len; i++)
            {
                cnts[s1[i] - 'a', i & 1]++; cnts[s2[i] - 'a', i & 1]--;
            }

            for (int i = 0; i < 26; i++) if (cnts[i, 0] != 0 || cnts[i, 1] != 0) return false;
            return true;
        }
    }
}
