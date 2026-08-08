using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2856
{
    public class Solution2856 : Interface2856
    {
        /// <summary>
        /// 贪心 + 大顶堆
        /// 优先碰撞掉数量多的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinLengthAfterRemovals(IList<int> nums)
        {
            List<(int, int)> list = new List<(int, int)>();
            int cnt = 1, len = nums.Count;
            for (int i = 1; i < len; i++)
            {
                if (nums[i] != nums[i - 1]) { list.Add((cnt, -cnt)); cnt = 1; } else cnt++;
            }
            list.Add((cnt, -cnt));

            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>(list);
            int x, y;
            while (maxpq.Count > 1)
            {
                x = maxpq.Dequeue();
                y = maxpq.Dequeue();
                x--; y--;
                if (x > 0) maxpq.Enqueue(x, -x);
                if (y > 0) maxpq.Enqueue(y, -y);
            }

            int result = 0;
            foreach (var kv in maxpq.UnorderedItems) result += kv.Element;
            return result;
        }
    }
}
