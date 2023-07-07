using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2532
{
    public class Solution2532 : Interface2532
    {
        /// <summary>
        /// 模拟
        /// 具体分析见Solution2532.md
        /// 
        /// 逻辑没问题，提交超时，参考测试用例03与04
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int FindCrossingTime(int n, int k, int[][] time)
        {
            int[] priority = new int[k];
            for (int i = 0; i < k; i++) priority[i] = -10000 * (time[i][0] + time[i][2]) - i;  // 工人过桥的优先级

            PriorityQueue<int, int> pq_left = new PriorityQueue<int, int>();                   // 桥左侧的等待队列
            Dictionary<int, int> set_left = new Dictionary<int, int>();                        // 桥左侧的放货集合
            PriorityQueue<int, int> pq_right = new PriorityQueue<int, int>();                  // 桥右侧的等待队列
            Dictionary<int, int> set_right = new Dictionary<int, int>();                       // 桥右侧的取货集合
            (int id, int time, int dir) bridge = (-1, -1, -1);                                 // 桥上的人，dir 0: left -> right; 2: right -> left，0与2对应数组的id
            for (int i = 0; i < k; i++) pq_left.Enqueue(i, priority[i]);                       // 初始化桥左侧的等待队列

            int result = -1;
            while (n > 0 || (bridge.id >= 0 && bridge.dir == 2) || set_right.Count > 0 || pq_right.Count > 0)
            {
                result++;
                foreach (int id in set_left.Keys)   // 左侧放货的工人
                {
                    set_left[id]++; if (set_left[id] == time[id][3])
                    {
                        pq_left.Enqueue(id, priority[id]); set_left.Remove(id);
                    }
                }
                foreach (int id in set_right.Keys)  // 右侧取货的工人
                {
                    set_right[id]++; if (set_right[id] == time[id][1])
                    {
                        pq_right.Enqueue(id, priority[id]); set_right.Remove(id);
                    }
                }
                if (bridge.id >= 0)  // 桥上有人
                {
                    bridge.time++; if (bridge.time == time[bridge.id][bridge.dir])
                    {
                        if (bridge.dir == 0)
                        {
                            if (n > 0)
                            {
                                set_right.Add(bridge.id, 0); n--;
                            }
                        }
                        else
                        {
                            set_left.Add(bridge.id, 0);
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
