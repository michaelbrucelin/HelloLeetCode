using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3507
{
    public class Solution3507 : Interface3507
    {
        /// <summary>
        /// 模拟
        /// 使用列表模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumPairRemoval(int[] nums)
        {
            int result = 0;
            List<int> list = [.. nums];
            bool flag = true;
            int min_sum, min_idx;
            while (flag && list.Count > 1)
            {
                flag = list[1] < list[0]; min_sum = list[0] + list[1]; min_idx = 1;
                for (int i = 2; i < list.Count; i++)
                {
                    if (list[i] < list[i - 1]) flag = true;
                    if (list[i] + list[i - 1] < min_sum) { min_sum = list[i] + list[i - 1]; min_idx = i; }
                }
                if (flag)
                {
                    result++;
                    list[min_idx - 1] += list[min_idx]; list.RemoveAt(min_idx);
                }
            }

            return result;
        }

        /// <summary>
        /// 逻辑完全同MinimumPairRemoval()，使用链表模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumPairRemoval2(int[] nums)
        {
            int result = 0;
            LinkedList<int> list = new LinkedList<int>(nums);
            bool flag = true;
            int min_sum; LinkedListNode<int> ptr, min_ptr;
            while (flag && list.Count > 1)
            {
                ptr = min_ptr = list.First.Next;
                flag = ptr.Value < ptr.Previous.Value; min_sum = ptr.Previous.Value + ptr.Value;
                while ((ptr = ptr.Next) != null)
                {
                    if (ptr.Value < ptr.Previous.Value) flag = true;
                    if (ptr.Value + ptr.Previous.Value < min_sum) { min_sum = ptr.Value + ptr.Previous.Value; min_ptr = ptr; }
                }
                if (flag)
                {
                    result++;
                    min_ptr.Previous.Value += min_ptr.Value; list.Remove(min_ptr);
                }
            }

            return result;
        }
    }
}
