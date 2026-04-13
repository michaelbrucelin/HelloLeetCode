using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2933
{
    public class Solution2933 : Interface2933
    {
        /// <summary>
        /// 分组排序
        /// </summary>
        /// <param name="access_times"></param>
        /// <returns></returns>
        public IList<string> FindHighAccessEmployees3(IList<IList<string>> access_times)
        {
            Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();
            foreach (List<string> access in access_times)
            {
                if (map.TryGetValue(access[0], out List<int> list))
                {
                    list.Add(int.Parse(access[1]));
                }
                else
                {
                    map.Add(access[0], [int.Parse(access[1])]);
                }
            }

            List<string> result = [];
            foreach (var kv in map)
            {
                kv.Value.Sort();
                for (int i = 2; i < kv.Value.Count; i++)
                {
                    if (kv.Value[i] - kv.Value[i - 2] < 100)
                    {
                        result.Add(kv.Key); break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 逻辑完全同FindHighAccessEmployees()，将List排序改为堆
        /// </summary>
        /// <param name="access_times"></param>
        /// <returns></returns>
        public IList<string> FindHighAccessEmployees(IList<IList<string>> access_times)
        {
            Dictionary<string, PriorityQueue<int, int>> map = new Dictionary<string, PriorityQueue<int, int>>();
            foreach (List<string> access in access_times)
            {
                if (map.TryGetValue(access[0], out var pq))
                {
                    pq.Enqueue(int.Parse(access[1]), int.Parse(access[1]));
                }
                else
                {
                    map.Add(access[0], new PriorityQueue<int, int>([(int.Parse(access[1]), int.Parse(access[1]))]));
                }
            }

            List<string> result = [];
            int first, second;
            foreach (var kv in map)
            {
                first = second = -1;
                while (kv.Value.Count > 0)
                {
                    if (first != -1 && kv.Value.Peek() - first < 100)
                    {
                        result.Add(kv.Key); break;
                    }
                    first = second; second = kv.Value.Dequeue();
                }
            }

            return result;
        }
    }
}
