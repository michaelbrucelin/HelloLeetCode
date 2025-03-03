using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0132
{
    public class Solution0132 : Interface0132
    {
        /// <summary>
        /// dfs + 记忆化搜索
        /// 预处理出每一个回文字串的起始位置和结束位置
        /// 先预处理出每个字符的位置
        /// 
        /// TLE，参考测试用例06，这里感受不到慢，平台估计是累计时间，因为这个是平台的倒数第2个测试用例
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinCut(string s)
        {
            List<int>[] dist = new List<int>[26];
            for (int i = 0; i < 26; i++) dist[i] = new List<int>();
            int len = s.Length;
            for (int i = 0; i < len; i++) dist[s[i] - 'a'].Add(i);                                       // 预处理出每个字符的位置

            SortedSet<int>[] subs = new SortedSet<int>[len];                                             // key 起点， value 终点
            Comparer<int> comparer = Comparer<int>.Create((x, y) => y - x);
            for (int i = 0; i < len; i++) subs[i] = new SortedSet<int>(comparer);
            for (int l = len - 1, r; l >= 0; l--) for (int i = dist[s[l] - 'a'].Count - 1; i >= 0; i--)  // 预处理出每一个回文字串的起始位置和结束位置
                {
                    if ((r = dist[s[l] - 'a'][i]) >= l)
                    {
                        if (check(l, r)) subs[l].Add(r);
                    }
                    else break;
                }
            if (subs[0].First() == len - 1) return 0;

            int[] memory = new int[len];
            Array.Fill(memory, -1);
            return dfs(0);

            int dfs(int l)
            {
                if (l == len || subs[l].First() == len - 1) return 0;
                if (memory[l] != -1) return memory[l];

                int result = len - l - 1, _cnt;
                foreach (int r in subs[l])
                {
                    _cnt = dfs(r + 1);
                    if (_cnt == 0) { result = 1; break; }
                    result = Math.Min(result, 1 + _cnt);
                }
                memory[l] = result;

                return result;
            }

            bool check(int l, int r)
            {
                while (l < r)
                {
                    if (subs[l].Contains(r)) return true;
                    if (s[l] != s[r]) return false;
                    l++;
                    r--;
                }
                return true;
            }
        }
    }
}
