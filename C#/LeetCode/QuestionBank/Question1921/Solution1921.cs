using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1921
{
    public class Solution1921 : Interface1921
    {
        /// <summary>
        /// 贪心 + 排序
        /// 1. 距离/速度向上取整就是到达起始位置的时间
        /// 2. 时间升序排序就是击杀的顺序
        /// 3. 当出现击杀的顺序大于到达起始位置的时间时，游戏结束
        /// </summary>
        /// <param name="dist"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public int EliminateMaximum(int[] dist, int[] speed)
        {
            int result = 0, len = dist.Length;
            int[] order = new int[len];
            for (int i = 0; i < len; i++)
                order[i] = (int)Math.Ceiling(1.0 * dist[i] / speed[i]);
            Array.Sort(order);
            for (int i = 0; i < len; i++)
                if (i < order[i]) result++; else break;

            return result;
        }

        /// <summary>
        /// 与EliminateMaximum()逻辑一样
        /// 只不过将数组排序改为了优先级队列，这样如果数组很长，但是在很靠前的位置就结束游戏，会更快
        /// </summary>
        /// <param name="dist"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public int EliminateMaximum2(int[] dist, int[] speed)
        {
            int result = 0, len = dist.Length;
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            for (int i = 0, val; i < len; i++)
            {
                val = (int)Math.Ceiling(1.0 * dist[i] / speed[i]);
                minpq.Enqueue(val, val);
            }

            int id = 0;
            while (minpq.Count > 0 && id++ < minpq.Dequeue()) result++;

            return result;
        }
    }
}
