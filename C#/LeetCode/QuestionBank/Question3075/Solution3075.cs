using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3075
{
    public class Solution3075 : Interface3075
    {
        /// <summary>
        /// 堆
        /// </summary>
        /// <param name="happiness"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaximumHappinessSum(int[] happiness, int k)
        {
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            foreach (int i in happiness) maxpq.Enqueue(i, -i);

            long result = 0, diff = 0, item;
            while (k-- > 0)
            {
                item = maxpq.Dequeue();
                if ((item -= diff) <= 0) break;
                result += item;
                diff++;
            }

            return result;
        }
    }
}
