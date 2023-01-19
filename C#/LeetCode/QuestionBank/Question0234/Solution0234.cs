using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0234
{
    public class Solution0234 : Interface0234
    {
        /// <summary>
        /// 使用List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head.next == null) return true;
            if (head.next.next == null) return head.val == head.next.val;

            List<int> list = new List<int>();
            ListNode ptr = head;
            while (ptr != null) { list.Add(ptr.val); ptr = ptr.next; }

            int left = 0, right = list.Count - 1;
            while (left < right) if (list[left++] != list[right--]) return false;

            return true;
        }

        /// <summary>
        /// 同IsPalindrome()，但是使用双指针可以将空间复杂度减半
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome2(ListNode head)
        {
            if (head.next == null) return true;
            if (head.next.next == null) return head.val == head.next.val;

            List<int> list = new List<int>() { head.val };
            ListNode slow = head, fast = head.next;
            while (fast != null && fast.next != null) { slow = slow.next; list.Add(slow.val); fast = fast.next.next; }

            if (fast != null) slow = slow.next;  // 链表节点是偶数个
            int id = list.Count - 1;
            while (id >= 0) if (slow.val != list[id--]) return false; else slow = slow.next;

            return true;
        }
    }
}
