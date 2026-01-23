using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3510
{
    public class Solution3510 : Interface3510
    {
        /// <summary>
        /// 模拟
        /// 使用 双向链表 + 堆 + 懒删除 来模拟
        /// 1. 将nums预处理双向链表
        /// 2. int cnt，记录相邻逆序对的数量，cnt = 0 时调整完成
        /// 3. PriorityQueue<(LinkedListNode<int>, LinkedListNode<int>), int> minpq，维护相邻数对的信息
        /// 4. HashSet<LinkedListNode> set，维护节点信息，用于堆的懒删除
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumPairRemoval(int[] nums)
        {
            if (nums.Length == 1) return 0;
            if (nums.Length == 2) return nums[0] > nums[1] ? 1 : 0;

            int result = 0, cnt = 0, idx = 0;
            // LinkedList<long> list = new LinkedList<long>(nums);
            LinkedList<long> list = new LinkedList<long>();
            foreach (long num in nums) list.AddLast(num);
            Comparer<(int, int)> comparer = Comparer<(int, int)>.Create((x, y) => x.Item1 != y.Item1 ? x.Item1 - y.Item1 : x.Item2 - y.Item2);
            PriorityQueue<(LinkedListNode<long>, int, LinkedListNode<long>, int), (long, int)> minpq = new PriorityQueue<(LinkedListNode<long>, int, LinkedListNode<long>, int), (long, int)>();
            HashSet<LinkedListNode<long>> set = new HashSet<LinkedListNode<long>>();
            set.Add(list.First);
            LinkedListNode<long> ptr = list.First;
            while ((ptr = ptr.Next) != null)
            {
                minpq.Enqueue((ptr.Previous, idx, ptr, idx + 1), (ptr.Previous.Value + ptr.Value, idx));
                set.Add(ptr);
                if (ptr.Value < ptr.Previous.Value) cnt++;
                idx++;
            }

            LinkedListNode<long> node1, node2; int idx1, idx2;
            while (cnt > 0)
            {
                (node1, idx1, node2, idx2) = minpq.Dequeue();
                while (!(set.Contains(node1) && set.Contains(node2))) (node1, idx1, node2, idx2) = minpq.Dequeue();
                if (node1.Value > node2.Value) cnt--;
                if (node1.Previous != null && node1.Previous.Value > node1.Value) cnt--;
                if (node2.Next != null && node2.Value > node2.Next.Value) cnt--;
                LinkedListNode<long> node = new LinkedListNode<long>(node1.Value + node2.Value);
                list.AddBefore(node1, node); list.Remove(node1); list.Remove(node2);
                set.Add(node); set.Remove(node1); set.Remove(node2);
                if (node.Previous != null)
                {
                    minpq.Enqueue((node.Previous, idx1 - 1, node, idx1), (node.Previous.Value + node.Value, idx1 - 1));
                    if (node.Previous.Value > node.Value) cnt++;
                }
                if (node.Next != null)
                {
                    minpq.Enqueue((node, idx2, node.Next, idx2 + 1), (node.Value + node.Next.Value, idx2));
                    if (node.Value > node.Next.Value) cnt++;
                }
                result++;
            }

            return result;
        }
    }
}