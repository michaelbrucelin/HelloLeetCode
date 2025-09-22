using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3508
{
    public class Solution3508
    {
    }

    /// <summary>
    /// 1. Queue<(int, int, int)>
    /// 2. HashSet<(int, int, int)> 辅助 AddPacket 验证是否有重复的包
    /// 3. Dictionary<int, List<(int, int)>> 辅助 GetCount 查询结果，二分查找
    /// 
    /// 不需要懒删除标记，需要删除的在List<T>的头部了
    /// 4. Dictionary<(int, int, int), int> 懒删除标记，GetCount 时删除 Dictionary 中的数据
    ///     删除的数据来自 AddPacket 与 ForwardPacket
    /// 之所以使用了额外的数据结构来懒删除标记，而不是直接在第一个HashSet中查找，是担心下面的数据
    /// ["Router","addPacket","addPacket","addPacket","addPacket","addPacket","forwardPacket","addPacket","getCount"]
    /// [[3],     [1,4,90],   [2,5,90],   [3,5,90],   [4,5,90],   [1,4,90],   [],             [5,2,110],  [4,10,100]]
    /// </summary>
    public class Router : Interface3508
    {
        public Router(int memoryLimit)
        {
            limit = memoryLimit;
            queue = new Queue<(int src, int dst, int ts)>();
            exists = new HashSet<(int src, int dst, int ts)>();
            // deleted = new Dictionary<(int src, int dst, int ts), int>();
            dests = new Dictionary<int, List<(int src, int ts)>>();
        }

        private int limit;
        Queue<(int, int, int)> queue;
        HashSet<(int, int, int)> exists;
        // Dictionary<(int, int, int), int> deleted;
        Dictionary<int, List<(int, int)>> dests;

        public bool AddPacket(int source, int destination, int timestamp)
        {
            if (exists.Contains((source, destination, timestamp))) return false;
            if (queue.Count == limit)
            {
                (int src, int dst, int ts) = queue.Dequeue();
                exists.Remove((src, dst, ts));
                dests[dst].RemoveAt(0);
            }
            queue.Enqueue((source, destination, timestamp));
            exists.Add((source, destination, timestamp));
            // if (dests.ContainsKey(destination)) dests[destination].Add((source, timestamp)); else dests.Add(destination, [(source, timestamp)]);
            if (dests.TryGetValue(destination, out List<(int, int)> value)) value.Add((source, timestamp)); else dests.Add(destination, [(source, timestamp)]);

            return true;
        }

        public int[] ForwardPacket()
        {
            if (queue.Count == 0) return [];

            (int src, int dst, int ts) = queue.Dequeue();
            exists.Remove((src, dst, ts));
            dests[dst].RemoveAt(0);
            return [src, dst, ts];
        }

        public int GetCount(int destination, int startTime, int endTime)
        {
            if (!dests.TryGetValue(destination, out List<(int src, int ts)> list) || list.Count == 0) return 0;
            if (startTime > list[^1].ts || endTime < list[0].ts) return 0;

            int cnt = list.Count;
            int start = cnt, end = -1, left, right, mid;

            left = 0; right = cnt - 1;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid].ts >= startTime)
                {
                    start = mid; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            if (start == cnt || list[start].ts > endTime) return 0;

            left = start; right = cnt - 1;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid].ts <= endTime)
                {
                    end = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return end - start + 1;
        }
    }
}
