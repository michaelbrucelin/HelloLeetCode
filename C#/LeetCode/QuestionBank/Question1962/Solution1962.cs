using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1962
{
    public class Solution1962 : Interface1962
    {
        /// <summary>
        /// 堆
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinStoneSum(int[] piles, int k)
        {
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            for (int i = 0; i < piles.Length; i++) maxpq.Enqueue(piles[i], -piles[i]);
            for (int i = 0, pile; i < k; i++)
            {
                if (maxpq.Peek() == 1) break;
                pile = maxpq.Dequeue();
                pile = (pile >> 1) + (pile & 1);
                maxpq.Enqueue(pile, -pile);
            }

            int result = 0, n = maxpq.Count + 1;
            while (--n > 0)
            {
                if (maxpq.Peek() == 1) { result += n; break; }
                result += maxpq.Dequeue();
            }

            return result;
        }
    }
}
