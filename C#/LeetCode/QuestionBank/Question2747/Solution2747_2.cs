using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2747
{
    public class Solution2747_2 : Interface2747
    {
        /// <summary>
        /// 滑动窗口
        /// 逻辑与Solution2747完全相同，不预处理全部的窗口，按需预处理
        /// 将queries排序，如果两次查询的窗口有重叠，滑动窗口，否则，重新开始滑动窗口
        /// 
        /// 逻辑没问题，依然TLE，反而更慢了... 超出时间限制 2126 / 3129 个通过的测试用例
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
            Dictionary<int, int> window = new Dictionary<int, int>();

            int[] result = new int[len];
            int[] queryid = new int[len];
            for (int i = 0; i < len; i++) queryid[i] = i;
            Array.Sort(queryid, (x, y) => queries[x] - queries[y]);
            Array.Sort(queries);
            int bid = -1, iid, oid;
            for (int i = 0, query; i < len; i++)
            {
                if ((query = queries[i]) <= bid)
                {
                    for (oid = bid - x, iid = bid + 1; iid <= query; oid++, iid++)
                    {
                        if (_logs.TryGetValue(iid, out var _set1)) foreach (int sid in _set1)
                            {
                                if (window.TryGetValue(sid, out int _cnt)) window[sid] = ++_cnt; else window.Add(sid, 1);
                            }
                        if (_logs.TryGetValue(oid, out var _set2)) foreach (int sid in _set2)
                            {
                                if (window[sid] == 1) window.Remove(sid); else window[sid]--;
                            }
                    }
                }
                else
                {
                    window.Clear();
                    for (iid = query - x; iid <= query; iid++) if (_logs.TryGetValue(iid, out var _set)) foreach (int sid in _set)
                            {
                                if (window.TryGetValue(sid, out int _cnt)) window[sid] = ++_cnt; else window.Add(sid, 1);
                            }
                }
                result[queryid[i]] = n - window.Count;
            }

            return result;
        }
    }
}
