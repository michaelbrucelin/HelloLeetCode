using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3741
{
    public class Solution3741 : Interface3741
    {
        /// <summary>
        /// Hash + 双链表
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumDistance(int[] nums)
        {
            int result = int.MaxValue, len = nums.Length;
            Dictionary<int, LinkedList<int>> map = new Dictionary<int, LinkedList<int>>();
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (map.TryGetValue(num, out var list))
                {
                    if (list.Count == 2)
                    {
                        result = Math.Min(result, i - list.First.Value);
                        list.RemoveFirst();
                    }
                    list.AddLast(i);
                }
                else
                {
                    map.Add(num, new LinkedList<int>([i]));
                }
            }

            return result != int.MaxValue ? result << 1 : -1;
        }

        /// <summary>
        /// 逻辑同MinimumDistance()，将双链表改为数组
        /// 
        /// 还是数组快，还是基本的数据结构快
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumDistance2(int[] nums)
        {
            int result = int.MaxValue, len = nums.Length;
            Dictionary<int, int[]> map = new Dictionary<int, int[]>();
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (map.TryGetValue(num, out var list))
                {
                    if (list[0] != -1) result = Math.Min(result, i - list[0]);
                    list[0] = list[1]; list[1] = i;
                }
                else
                {
                    map.Add(num, [-1, i]);
                }
            }

            return result != int.MaxValue ? result << 1 : -1;
        }
    }
}
