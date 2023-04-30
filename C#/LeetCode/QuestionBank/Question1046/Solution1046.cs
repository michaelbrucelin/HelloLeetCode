using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1046
{
    public class Solution1046 : Interface1046
    {
        public int LastStoneWeight(int[] stones)
        {
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
            for (int i = 0; i < stones.Length; i++) queue.Enqueue(stones[i], -stones[i]);
            while (queue.Count > 1)
            {
                int x = queue.Dequeue(), y = queue.Dequeue();
                if (x > y) queue.Enqueue(x - y, y - x);
            }

            return queue.Count > 0 ? queue.Dequeue() : 0;
        }
    }
}
