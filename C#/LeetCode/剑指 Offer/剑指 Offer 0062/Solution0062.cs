using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0062
{
    public class Solution0062 : Interface0062
    {
        /// <summary>
        /// 使用数组模拟
        /// 
        /// 提交会超时，参考测试用例4
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int LastRemaining(int n, int m)
        {
            bool[] mask = new bool[n];  // true: 被移除

            for (int cnt = n, ptr = -1, step; cnt > 1; cnt--)
            {
                step = (m - 1) % cnt + 1;
                for (int i = 0; i < step; i++)
                {
                    ptr = (ptr + 1) % n;
                    while (mask[ptr]) ptr = (ptr + 1) % n;
                }
                mask[ptr] = true;
            }

            for (int i = 0; i < n; i++) if (!mask[i]) return i;
            throw new Exception("Error Implement.");
        }

        /// <summary>
        /// 使用数组模拟
        /// 
        /// 本地测试已经比LastRemaining()快了不少，但是提交仍然会超时，参考测试用例4
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int LastRemaining2(int n, int m)
        {
            List<int> nums = new List<int>(n); for (int i = 0; i < n; i++) nums.Add(i);

            for (int cnt = n, ptr = 0, step; cnt > 1; cnt--)
            {
                step = (m - 1) % cnt + 1;
                ptr = (ptr + step - 1) % cnt;
                nums.RemoveAt(ptr);
            }

            return nums[0];
        }

        /// <summary>
        /// 使用队列模拟
        /// 
        /// 本地测试速度比LastRemaining2()慢，没有提交测试
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int LastRemaining3(int n, int m)
        {
            Queue<int> queue = new Queue<int>(); for (int i = 0; i < n; i++) queue.Enqueue(i);

            for (int cnt = n, ptr = 0, step; cnt > 1; cnt--)
            {
                step = (m - 1) % cnt + 1;
                for (int i = 0; i < step - 1; i++) queue.Enqueue(queue.Dequeue());
                queue.Dequeue();
            }

            return queue.Dequeue();
        }

        /// <summary>
        /// 使用链表模拟
        /// 
        /// 本地测试速度比LastRemaining2()慢，没有提交测试
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int LastRemaining4(int n, int m)
        {
            LinkedList<int> nums = new LinkedList<int>(); for (int i = 0; i < n; i++) nums.AddLast(i);

            LinkedListNode<int> ptr = nums.First, _ptr;
            for (int cnt = n, step; cnt > 1; cnt--)
            {
                step = (m - 1) % cnt + 1;
                for (int i = 0; i < step - 1; i++) ptr = ptr.Next != null ? ptr.Next : nums.First;
                _ptr = ptr; ptr = ptr.Next != null ? ptr.Next : nums.First;
                nums.Remove(_ptr);
            }

            return nums.First.Value;
        }
    }
}
