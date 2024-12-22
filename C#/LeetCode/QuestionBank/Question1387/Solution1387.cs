using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1387
{
    public class Solution1387 : Interface1387
    {
        /// <summary>
        /// 大顶堆
        /// </summary>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetKth(int lo, int hi, int k)
        {
            Comparer<(int w, int v)> comparer = Comparer<(int w, int v)>.Create((t1, t2) => t1.w != t2.w ? t2.w - t1.w : t2.v - t1.v);
            PriorityQueue<int, (int, int)> maxpq = new PriorityQueue<int, (int, int)>(comparer);
            for (int i = lo, w; i <= hi; i++)
            {
                w = GetWeight(i);
                maxpq.Enqueue(i, (w, i));
                if (maxpq.Count > k) maxpq.Dequeue();
            }

            return maxpq.Dequeue();

            int GetWeight(int x)
            {
                int step = 0;
                while (x != 1)
                {
                    x = (x & 1) == 0 ? x >> 1 : x * 3 + 1;
                    step++;
                }

                return step;
            }
        }
    }
}
