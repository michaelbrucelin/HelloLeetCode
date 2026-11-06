using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2747
{
    public class Solution2747 : Interface2747
    {
        /// <summary>
        /// 滑动窗口
        /// 注意到题目每次查询的区间宽度是固定的，可以使用滑动窗口预处理出所有的结果
        /// 
        /// 逻辑没问题，TLE，单独执行看不出时间差异，LeetCode应该是所有测试用例累计时间
        /// 超出时间限制 2580 / 3129 个通过的测试用例
        /// </summary>
        /// <param name="n"></param>
        /// <param name="logs"></param>
        /// <param name="x"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] CountServers(int n, int[][] logs, int x, int[] queries)
        {
            Dictionary<int, HashSet<int>> _logs = new Dictionary<int, HashSet<int>>();
            foreach (int[] log in logs) if (_logs.TryGetValue(log[1], out var _set)) _set.Add(log[0]); else _logs.Add(log[1], [log[0]]);

            int maxtime = 0, len = queries.Length;
            for (int i = 0; i < len; i++) maxtime = Math.Max(maxtime, queries[i]);
            int[] buffer = new int[maxtime - x + 1];
            Dictionary<int, int> window = new Dictionary<int, int>();
            for (int i = 0; i <= x; i++) if (_logs.TryGetValue(i, out var _set)) foreach (int sid in _set)
                    {
                        if (window.TryGetValue(sid, out int _cnt)) window[sid] = ++_cnt; else window.Add(sid, 1);
                    }
            buffer[0] = window.Count;
            for (int oid = 0, iid = x + 1; iid <= maxtime; oid++, iid++)
            {
                if (_logs.TryGetValue(iid, out var _set1)) foreach (int sid in _set1)
                    {
                        if (window.TryGetValue(sid, out int _cnt)) window[sid] = ++_cnt; else window.Add(sid, 1);
                    }
                if (_logs.TryGetValue(oid, out var _set2)) foreach (int sid in _set2)
                    {
                        if (window[sid] == 1) window.Remove(sid); else window[sid]--;
                    }
                buffer[oid + 1] = window.Count;
            }

            int[] result = new int[len];
            for (int i = 0; i < len; i++) result[i] = n - buffer[queries[i] - x];

            return result;
        }
    }
}
