using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1733
{
    public class Solution1733 : Interface1733
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="n"></param>
        /// <param name="languages"></param>
        /// <param name="friendships"></param>
        /// <returns></returns>
        public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
        {
            int m = languages.Length;
            HashSet<int>[] langs = new HashSet<int>[m + 1];
            for (int i = 1; i <= m; i++) langs[i] = [.. languages[i - 1]];
            List<int[]> friends = new List<int[]>();
            foreach (int[] item in friendships) if (!langs[item[0]].Overlaps(langs[item[1]])) friends.Add(item);

            int result = m, _result;
            HashSet<int>[] _langs;
            for (int i = 1; i <= n; i++)
            {
                _result = 0;
                _langs = new HashSet<int>[m + 1];
                foreach (int[] item in friends)
                {
                    if (_langs[item[0]] == null) _langs[item[0]] = [.. langs[item[0]]];
                    if (!_langs[item[0]].Contains(i)) { _result++; _langs[item[0]].Add(i); }
                    if (_langs[item[1]] == null) _langs[item[1]] = [.. langs[item[1]]];
                    if (!_langs[item[1]].Contains(i)) { _result++; _langs[item[1]].Add(i); }
                }
                result = Math.Min(result, _result);
            }

            return result;
        }
    }
}
