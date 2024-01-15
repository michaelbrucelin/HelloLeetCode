using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2073
{
    public class Solution2073 : Interface2073
    {
        /// <summary>
        /// 模拟，队列
        /// </summary>
        /// <param name="tickets"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            Queue<(int id, int cnt)> queue = new Queue<(int id, int cnt)>();
            for (int i = 0; i < tickets.Length; i++) queue.Enqueue((i, tickets[i]));

            int result = 0;
            (int id, int cnt) info;
            while (true)
            {
                result++;
                info = queue.Dequeue();
                info.cnt--;
                if (info.cnt > 0) queue.Enqueue(info); else if (info.id == k) break;
            }

            return result;
        }
    }
}
