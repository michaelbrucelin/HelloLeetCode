using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0833
{
    public class Solution0833 : Interface0833
    {
        /// <summary>
        /// 排序 + 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <param name="indices"></param>
        /// <param name="sources"></param>
        /// <param name="targets"></param>
        /// <returns></returns>
        public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            StringBuilder result = new StringBuilder();
            int p1 = 0, p2 = 0, p, id, len, len1 = s.Length, len2 = indices.Length;
            int[] indexes = new int[len2];
            for (int i = 0; i < len2; i++) indexes[i] = i;
            Array.Sort(indexes, (i, j) => indices[i] - indices[j]);
            while (p1 < len1 && p2 < len2 && (p = indices[(id = indexes[p2])]) < len1)
            {
                len = sources[id].Length;
                while (p1 < p) result.Append(s[p1++]);
                if (p1 + len - 1 < len1 && CheckEqual(s, p1, sources[id]))
                {
                    result.Append(targets[id]); p1 += len;
                }
                p2++;
            }
            while (p1 < len1) result.Append(s[p1++]);

            return result.ToString();
        }

        private bool CheckEqual(string s, int start, string t)
        {
            for (int i = start, j = 0; j < t.Length; i++, j++)
                if (s[i] != t[j]) return false;
            return true;
        }
    }
}
