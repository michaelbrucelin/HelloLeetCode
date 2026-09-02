using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0967
{
    public class Solution0967 : Interface0967
    {
        /// <summary>
        /// BFS
        /// 先计算n位的，再计算n+1位的
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] NumsSameConsecDiff(int n, int k)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 1; i < 10; i++) queue.Enqueue(i);
            while (--n > 0) for (int i = queue.Count, x, y; i > 0; i--)
                {
                    x = queue.Dequeue();
                    y = x % 10;
                    if (y + k < 10) queue.Enqueue(x * 10 + y + k);
                    if (k != 0 && y - k >= 0) queue.Enqueue(x * 10 + y - k);
                }

            int cnt = queue.Count;
            int[] result = new int[cnt];
            while (--cnt >= 0) result[cnt] = queue.Dequeue();
            return result;
        }
    }
}
