using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1561
{
    public class Solution1561 : Interface1561
    {
        /// <summary>
        /// 贪心 + 大顶堆
        /// 获取第2, 4, 6 ... 大的元素即可
        /// </summary>
        /// <param name="piles"></param>
        /// <returns></returns>
        public int MaxCoins(int[] piles)
        {
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            foreach (int pile in piles) maxpq.Enqueue(pile, -pile);

            int result = 0, times = piles.Length / 3;
            for (int i = 0; i < times; i++)
            {
                maxpq.Dequeue();
                result += maxpq.Dequeue();
            }

            return result;
        }
    }
}
