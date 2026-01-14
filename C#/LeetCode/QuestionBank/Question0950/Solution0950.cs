using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0950
{
    public class Solution0950 : Interface0950
    {
        /// <summary>
        /// 队列模拟
        /// 拿纸画画就看清楚过程了
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public int[] DeckRevealedIncreasing(int[] deck)
        {
            if (deck.Length == 1) return deck;

            int len = deck.Length;
            int[] result = new int[len], order = new int[len];
            for (int i = 0; i < len; i++) order[i] = deck[i];
            Array.Sort(order);
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < len; i++) queue.Enqueue(i);
            for (int i = 0; i < len; i++)
            {
                result[queue.Dequeue()] = order[i];
                if (queue.Count > 0) queue.Enqueue(queue.Dequeue());
            }

            return result;
        }

        /// <summary>
        /// 逻辑完全同DeckRevealedIncreasing()，稍稍优化
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public int[] DeckRevealedIncreasing2(int[] deck)
        {
            if (deck.Length == 1) return deck;

            int len = deck.Length;
            int[] result = new int[len], order = new int[len];
            for (int i = 0; i < len; i++) order[i] = deck[i];
            Array.Sort(order);
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < len; i++) queue.Enqueue(i);
            len--;
            for (int i = 0; i < len; i++)
            {
                result[queue.Dequeue()] = order[i];
                queue.Enqueue(queue.Dequeue());
            }
            result[queue.Dequeue()] = order[^1];

            return result;
        }
    }
}
