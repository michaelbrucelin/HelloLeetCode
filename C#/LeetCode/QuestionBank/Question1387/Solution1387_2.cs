using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1387
{
    public class Solution1387_2 : Interface1387
    {
        /// <summary>
        /// 大顶堆 + 记忆化
        /// 逻辑同Solution1387，计算weight时增加记忆化搜索
        /// </summary>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetKth(int lo, int hi, int k)
        {
            Comparer<(int w, int v)> comparer = Comparer<(int w, int v)>.Create((t1, t2) => t1.w != t2.w ? t2.w - t1.w : t2.v - t1.v);
            PriorityQueue<int, (int, int)> maxpq = new PriorityQueue<int, (int, int)>(comparer);
            Dictionary<int, int> memory = new Dictionary<int, int>();
            for (int i = lo, w; i <= hi; i++)
            {
                w = GetWeight(i);
                maxpq.Enqueue(i, (w, i));
                if (maxpq.Count > k) maxpq.Dequeue();
            }

            return maxpq.Dequeue();

            int GetWeight(int x)
            {
                if (memory.ContainsKey(x)) return memory[x];

                int step = 0, _x = x;
                while (_x != 1)
                {
                    if (memory.ContainsKey(_x))
                    {
                        step += memory[_x];
                        break;
                    }
                    else
                    {
                        _x = (_x & 1) == 0 ? _x >> 1 : _x * 3 + 1;
                        step++;
                    }
                }
                memory.Add(x, step);

                return memory[x];
            }
        }
    }
}
