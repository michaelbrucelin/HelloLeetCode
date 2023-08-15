using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0833
{
    public class Solution0833_2 : Interface0833
    {
        /// <summary>
        /// 遍历 + 不排序
        /// </summary>
        /// <param name="s"></param>
        /// <param name="indices"></param>
        /// <param name="sources"></param>
        /// <param name="targets"></param>
        /// <returns></returns>
        public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            int p, len1 = s.Length, len2 = indices.Length;
            string[] strs = new string[len1];
            for (int i = 0; i < len1; i++) strs[i] = s[i].ToString();
            for (int i = 0; i < len2; i++)
            {
                p = indices[i];
                if (CheckEqual(s, p, sources[i]))
                {
                    strs[p] = targets[i];
                    for (int j = p + 1; j < p + sources[i].Length; j++) strs[j] = null;
                }
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < len1; i++) if (strs[i] != null) result.Append(strs[i]);

            return result.ToString();
        }

        private bool CheckEqual(string s, int start, string t)
        {
            if (start + t.Length > s.Length) return false;
            for (int i = start, j = 0; j < t.Length; i++, j++)
                if (s[i] != t[j]) return false;
            return true;
        }
    }
}
