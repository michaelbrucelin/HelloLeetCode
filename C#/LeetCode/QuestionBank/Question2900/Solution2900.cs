using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2900
{
    public class Solution2900 : Interface2900
    {
        /// <summary>
        /// 分类讨论，遍历
        /// 从groups中选取一个子序列，使子序列中相邻的元素不同，由于groups中只有0和1，所以最终结果只有两种可能
        ///     0 1 0 1 0 1 ... ...
        ///     1 0 1 0 1 0 ... ...
        /// </summary>
        /// <param name="words"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        public IList<string> GetLongestSubsequence(string[] words, int[] groups)
        {
            List<int> list01 = new List<int>(), list10 = new List<int>();
            int id, len = groups.Length;
            // 0 1 0 1 0 1 ...
            for (id = 0; id < len; id++) if (groups[id] == 0) { list01.Add(id); break; }
            for (; id < len; id++) if (groups[id] != groups[list01[^1]]) list01.Add(id);
            // 1 0 1 0 1 0 ...
            for (id = 0; id < len; id++) if (groups[id] == 1) { list10.Add(id); break; }
            for (; id < len; id++) if (groups[id] != groups[list10[^1]]) list10.Add(id);

            IList<string> result = new List<string>();
            if (list01.Count >= list10.Count)
            {
                for (int i = 0; i < list01.Count; i++) result.Add(words[list01[i]]);
            }
            else
            {
                for (int i = 0; i < list10.Count; i++) result.Add(words[list10[i]]);
            }
            return result;
        }

        /// <summary>
        /// 更本质的，如果groups[0] == 0，那么一定是 0 1 0 1 ...，否则，一定是 1 0 1 0 ...
        /// </summary>
        /// <param name="words"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        public IList<string> GetLongestSubsequence2(string[] words, int[] groups)
        {
            List<int> list = new List<int>() { 0 };
            for (int i = 1; i < groups.Length; i++) if (groups[i] != groups[list[^1]]) list.Add(i);

            IList<string> result = new string[list.Count];
            for (int i = 0; i < list.Count; i++) result[i] = words[list[i]];

            return result;
        }
    }
}
