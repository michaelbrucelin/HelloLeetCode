using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0264
{
    public class Solution0264 : Interface0264
    {
        /// <summary>
        /// 类DP
        /// 第1个元素是1
        /// 假定第n个元素是x，然后将x*2, x*3, x*5放入小顶堆中，那么第n+1个元素就是小顶堆的堆顶
        /// 注意需要用Hash表去重复
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber(int n)
        {
            if (n < 7) return n;

            PriorityQueue<long, long> minpq = new PriorityQueue<long, long>();
            HashSet<long> set = new HashSet<long>();
            minpq.Enqueue(1, 1); set.Add(1);
            long x, _x;
            while (--n > 0)
            {
                x = minpq.Dequeue();
                if (set.Add(_x = x * 2)) minpq.Enqueue(_x, _x);
                if (set.Add(_x = x * 3)) minpq.Enqueue(_x, _x);
                if (set.Add(_x = x * 5)) minpq.Enqueue(_x, _x);
            }

            return (int)minpq.Dequeue();
        }
    }
}
