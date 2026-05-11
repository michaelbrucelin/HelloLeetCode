using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1296
{
    public class Solution1296 : Interface1296
    {
        /// <summary>
        /// 贪心
        /// 借助小顶堆 + Hash实现贪心，从小顶堆弹出一个元素 x，那么余下的项中必须包含 x+1, x+2, ... x+k-1
        /// 通过查询Hash可以知道 x+1, x+2, ... x+k-1 是否存在，并使用另一个Hash记录这些值，因为小顶堆需要懒删除
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool IsPossibleDivide(int[] nums, int k)
        {
            if (k == 1) return true;
            if (nums.Length % k != 0) return false;

            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            Dictionary<int, int> map1 = new Dictionary<int, int>(), map2 = new Dictionary<int, int>();
            for (int i = 0, num, len = nums.Length; i < len; i++)
            {
                num = nums[i];
                minpq.Enqueue(num, num);
                if (map1.TryGetValue(num, out int cnt)) { map1[num] = cnt + 1; } else { map1.Add(num, 1); map2.Add(num, 0); }
            }

            int x = 0;
            while (minpq.Count > 0)
            {
                while (minpq.Count > 0 && map2[x = minpq.Dequeue()] > 0) { map2[x]--; }
                if (minpq.Count == 0) break;
                map1[x]--;
                for (int i = 1; i < k; i++)
                {
                    if (!map1.TryGetValue(++x, out int value) || value == 0) return false;
                    map1[x] = value - 1; map2[x]++;
                }
            }

            return true;
        }
    }
}
