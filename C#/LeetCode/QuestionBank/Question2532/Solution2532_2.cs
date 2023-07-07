using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2532
{
    public class Solution2532_2 : Interface2532
    {
        /// <summary>
        /// 与Solution2532逻辑一样，但是将两个集合（pick与put）由字典改为优先级队列，这样可以提高这部分的性能
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int FindCrossingTime(int n, int k, int[][] time)
        {
            int[] priority = new int[k];
            for (int i = 0; i < k; i++) priority[i] = -10000 * (time[i][0] + time[i][2]) - i;                 // 工人过桥的优先级

            PriorityQueue<int, int> pq_left = new PriorityQueue<int, int>();                                  // 桥左侧的等待队列
            PriorityQueue<(int id, int time), int> set_left = new PriorityQueue<(int id, int time), int>();   // 桥左侧的放货集合
            PriorityQueue<int, int> pq_right = new PriorityQueue<int, int>();                                 // 桥右侧的等待队列
            PriorityQueue<(int id, int time), int> set_right = new PriorityQueue<(int id, int time), int>();  // 桥右侧的取货集合
            (int id, int time, int dir) bridge = (-1, -1, -1);                                                // 桥上的人，dir 0: left -> right; 2: right -> left，0与2对应数组的id
            for (int i = 0; i < k; i++) pq_left.Enqueue(i, priority[i]);                                      // 初始化桥左侧的等待队列

            int result = -1;
            while (n > 0 || (bridge.id >= 0 && bridge.dir == 2) || set_right.Count > 0 || pq_right.Count > 0)
            {
                result++;
                while (set_left.Count > 0 && set_left.Peek().time <= result)    // 左侧放货的工人
                {
                    int id = set_left.Dequeue().id; pq_left.Enqueue(id, priority[id]);
                }
                while (set_right.Count > 0 && set_right.Peek().time <= result)  // 右侧取货的工人
                {
                    int id = set_right.Dequeue().id; pq_right.Enqueue(id, priority[id]);
                }
                if (bridge.id >= 0)  // 桥上有人
                {
                    bridge.time++; if (bridge.time == time[bridge.id][bridge.dir])
                    {
                        if (bridge.dir == 0)
                        {
                            if (n > 0)
                            {
                                set_right.Enqueue((bridge.id, result + time[bridge.id][1]), result + time[bridge.id][1]); n--;
                            }
                        }
                        else
                        {
                            set_left.Enqueue((bridge.id, result + time[bridge.id][3]), result + time[bridge.id][3]);
                        }
                        bridge.id = -1;
                    }
                }
                if (bridge.id < 0)   // 桥上无人
                {
                    if (pq_right.Count > 0)
                    {
                        bridge = (pq_right.Dequeue(), 0, 2);
                    }
                    else
                    {
                        if (n > 0 && pq_left.Count > 0) bridge = (pq_left.Dequeue(), 0, 0);
                    }
                }
            }

            return result;
        }
    }
}
