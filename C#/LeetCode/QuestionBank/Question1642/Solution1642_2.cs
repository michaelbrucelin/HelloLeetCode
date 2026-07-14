using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1642
{
    public class Solution1642_2 : Interface1642
    {
        /// <summary>
        /// 贪心
        /// 首先梯子应该用在落差大的位置，但是如果落差大的位置都在最后边，可能都到达不了
        /// 所以，可以一直用砖，并用大顶堆记录每次用了多少砖，如果砖不够用，就将堆顶的砖“恢复”，改用梯子
        /// </summary>
        /// <param name="heights"></param>
        /// <param name="bricks"></param>
        /// <param name="ladders"></param>
        /// <returns></returns>
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            if (ladders >= heights.Length - 1) return heights.Length - 1;

            int ptr = -1, diff, len = heights.Length - 1;
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            while (++ptr < len)
            {
                if (heights[ptr + 1] <= heights[ptr]) continue;
                diff = heights[ptr + 1] - heights[ptr];
                if (diff > bricks && ladders == 0) break;
                RETRY:;
                if (diff <= bricks)
                {
                    bricks -= diff;
                    maxpq.Enqueue(diff, -diff);
                }
                else
                {
                    if (maxpq.Count == 0 || diff >= maxpq.Peek())
                    {
                        ladders--;
                    }
                    else
                    {
                        ladders--;
                        bricks += maxpq.Dequeue();
                        goto RETRY;
                    }
                }
            }

            return ptr;
        }
    }
}
