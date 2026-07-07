using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0841
{
    public class Solution0841 : Interface0841
    {
        /// <summary>
        /// 模拟
        /// 使用Hash模拟
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            int n = rooms.Count;
            HashSet<int> set = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            int room;
            while (queue.Count > 0)
            {
                room = queue.Dequeue();
                if (set.Add(room))
                {
                    if (set.Count == n) return true;
                    foreach (int next in rooms[room]) if (!set.Contains(next)) queue.Enqueue(next);
                }
            }

            return false;
        }

        /// <summary>
        /// 逻辑同CanVisitAllRooms()，使用数组代替Hash
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        public bool CanVisitAllRooms2(IList<IList<int>> rooms)
        {
            int n = rooms.Count;
            bool[] set = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            int room, cnt = 0;
            while (queue.Count > 0)
            {
                room = queue.Dequeue();
                if (!set[room])
                {
                    set[room] = true;
                    if (++cnt == n) return true;
                    foreach (int next in rooms[room]) if (!set[next]) queue.Enqueue(next);
                }
            }

            return false;
        }
    }
}
