using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1520
{
    public class Solution1520_err : Interface1520
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 例如：s = "adefaddaccc"
        /// 1. 预处理出每个字符第一次与最后一次出现的位置
        /// 2. 从前向后遍历每一个字符
        ///     第1个字符 a，独立子串，dfs(s, start, end)， s[start,end] 为 ccc
        ///                  放弃掉a ，dfs(s, 1, end)
        ///     ...
        ///     第n个字符 ?，如果前面没有 ?，可以像处理第一个字符一样，决定“取”还是“放弃”
        ///                  如果前面有 ?，必然放弃，如果“取”，前面就已经“取”了
        /// 
        /// 思路完全是错误的，参考测试用例03
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> MaxNumOfSubstrings(string s)
        {
            int len = s.Length;
            int[,] pos = new int[26, 2];
            for (int i = 0; i < 26; i++) pos[i, 0] = pos[i, 1] = -1;
            for (int i = 0, j; i < len; i++)
            {
                pos[j = s[i] - 'a', 1] = i;
                if (pos[j, 0] == -1) pos[j, 0] = i;
            }

            (int, int, List<(int, int)>)[] memory = new (int, int, List<(int, int)>)[len];  // cnt, len, splits
            (int, int, List<(int, int)>) info = dfs(s, 0, pos, memory);
            List<string> result = new List<string>();
            foreach ((int start, int end) in info.Item3) result.Add(s[start..(end + 1)]);
            return result;

            static (int, int, List<(int, int)>) dfs(string s, int start, int[,] pos, (int, int, List<(int, int)>)[] memory)
            {
                if (start == s.Length) return (0, 0, []);
                if (memory[start].Item1 != 0) return memory[start];

                int idx = s[start] - 'a';
                if (pos[idx, 0] < start) return dfs(s, start + 1, pos, memory);
                int cnt, len, end = pos[idx, 1]; List<(int, int)> list;
                // s[start]成为子串
                (int, int, List<(int, int)>) t = dfs(s, end + 1, pos, memory);
                (cnt, len, list) = (t.Item1 + 1, t.Item2 + end - start + 1, [(start, end), .. t.Item3]);
                // s[start]不成为子串
                t = dfs(s, start + 1, pos, memory);
                if (t.Item1 > cnt || (t.Item1 == cnt && t.Item2 < len)) (cnt, len, list) = t;

                memory[start] = (cnt, len, list);
                return (cnt, len, list);
            }
        }
    }
}
