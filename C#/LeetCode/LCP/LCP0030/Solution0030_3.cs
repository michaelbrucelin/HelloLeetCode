using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0030
{
    public class Solution0030_3 : Interface0030
    {
        /// <summary>
        /// 贪心 + 模拟
        /// 1. 用一个队列记录nums中的值
        /// 2. 用一个优先级队列记录已经消耗掉的负值
        /// 3. 如果血量小于等于0，将已经消耗掉的负值中的最小值移到最后
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MagicTower(int[] nums)
        {
            int result = 0; long blood = 1;
            Queue<int> queue = new Queue<int>();
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            for (int i = 0, num, _num; i < nums.Length; i++)
            {
                if ((num = nums[i]) < 0) minpq.Enqueue(num, num);
                if ((blood += num) <= 0)  // 此时minpq必不为空，且一定移动一个最小的负值blood即可大于0
                {
                    _num = minpq.Dequeue(); blood -= _num; queue.Enqueue(_num);
                    result++;
                }
            }
            while (queue.Count > 0)
            {
                if ((blood += queue.Dequeue()) <= 0) return -1;
            }

            return result;
        }

        /// <summary>
        /// 逻辑同MagicTower()，不需要队列来记录移到后面的值，只需要记录这部分值的和即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MagicTower2(int[] nums)
        {
            int result = 0; long blood = 1, renums = 0;
            PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
            for (int i = 0, num, _num; i < nums.Length; i++)
            {
                if ((num = nums[i]) < 0) minpq.Enqueue(num, num);
                if ((blood += num) <= 0)  // 此时minpq必不为空，且一定移动一个最小的负值blood即可大于0
                {
                    _num = minpq.Dequeue(); blood -= _num; renums += _num;
                    result++;
                }
            }

            return blood >= -renums ? result : -1;
        }
    }
}
