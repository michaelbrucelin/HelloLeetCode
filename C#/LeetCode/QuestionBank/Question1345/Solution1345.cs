using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1345
{
    public class Solution1345 : Interface1345
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MinJumps(int[] arr)
        {
            if (arr.Length == 1) return 0;
            if (arr.Length == 2 || arr[0] == arr[^1]) return 1;

            int len = arr.Length;
            Dictionary<int, List<int>> dist = new Dictionary<int, List<int>>();
            for (int i = 0, num; i < len; i++) if (dist.TryGetValue(num = arr[i], out List<int> _list)) _list.Add(i); else dist.Add(num, [i]);

            int result = 0, cnt, idx;
            bool[] visited = new bool[len];
            Queue<int> queue = new Queue<int>(); queue.Enqueue(0);
            while ((cnt = queue.Count) > 0)
            {
                result++;
                for (int i = 0; i < cnt; i++)
                {
                    if (visited[idx = queue.Dequeue()]) continue;
                    if (idx == len - 2 || arr[idx] == arr[^1]) goto FOUND;
                    visited[idx] = true;
                    if (idx - 1 >= 0) queue.Enqueue(idx - 1);
                    if (idx + 1 < len) queue.Enqueue(idx + 1);
                    foreach (int _idx in dist[arr[idx]]) queue.Enqueue(_idx);
                    dist[arr[idx]].Clear();
                }
            }
        FOUND:;

            return result;
        }
    }
}
