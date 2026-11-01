using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3834
{
    public class Solution3834 : Interface3834
    {
        /// <summary>
        /// 模拟
        /// 用一个索引数组模拟双链表
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<long> MergeAdjacent(int[] nums)
        {
            int len = nums.Length;
            long[] _nums = new long[len];
            int[,] link = new int[len, 2];
            for (int i = 0; i < len; i++) { _nums[i] = nums[i]; link[i, 0] = i - 1; link[i, 1] = i + 1; }
            link[len - 1, 1] = -1;

            int id = 0;
            while (link[id, 1] != -1)
            {
                if (_nums[id] != _nums[link[id, 1]])
                {
                    id = link[id, 1];
                }
                else
                {
                    _nums[id] <<= 1;
                    link[id, 1] = link[link[id, 1], 1];
                    if (link[id, 1] != -1) link[link[id, 1], 0] = id;
                    if (link[id, 0] != -1) id = link[id, 0];
                }
            }

            List<long> result = new List<long>();
            id = 0;
            do { result.Add(_nums[id]); } while ((id = link[id, 1]) != -1);
            return result;
        }

        /// <summary>
        /// 逻辑与MergeAdjacent()完全相同，使用.net内置的双链表
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<long> MergeAdjacent2(int[] nums)
        {
            int len = nums.Length;
            LinkedList<long> link = new LinkedList<long>([.. nums]);

            LinkedListNode<long> ptr = link.First;
            while (ptr.Next != null)
            {
                if (ptr.Value != ptr.Next.Value)
                {
                    ptr = ptr.Next;
                }
                else
                {
                    ptr.Value <<= 1;
                    link.Remove(ptr.Next);
                    if (ptr.Previous != null) ptr = ptr.Previous;
                }
            }

            List<long> result = new List<long>();
            ptr = link.First;
            do { result.Add(ptr.Value); } while ((ptr = ptr.Next) != null);
            return result;
        }
    }
}
