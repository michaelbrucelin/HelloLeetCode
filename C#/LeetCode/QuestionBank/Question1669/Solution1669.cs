using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1669
{
    public class Solution1669 : Interface1669
    {
        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            ListNode left = list1, right = list1, mid = list2;
            for (int i = 0; i <= b - a; i++) right = right.next;
            for (int i = 0; i < a - 1; i++) { right = right.next; left = left.next; }
            while (mid.next != null) mid = mid.next;
            left.next = list2; mid.next = right.next; right.next = null;

            return list1;
        }

        /// <summary>
        /// MergeInBetween()中使用了类似于快慢指针的方式操作，不过没有实际意义
        /// 这里使用最直接的方式编码
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeInBetween2(ListNode list1, int a, int b, ListNode list2)
        {
            ListNode left = list1, right = list1, mid = list2;
            for (int i = 0; i < a - 1; i++) left = left.next;
            for (int i = 0; i < b; i++) right = right.next;
            while (mid.next != null) mid = mid.next;
            left.next = list2; mid.next = right.next; right.next = null;

            return list1;
        }

        /// <summary>
        /// MergeInBetween2()还是可以优化的
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeInBetween3(ListNode list1, int a, int b, ListNode list2)
        {
            ListNode left = list1;
            for (int i = 0; i < a - 1; i++) left = left.next;
            ListNode right = left;
            for (int i = 0; i < b - a + 1; i++) right = right.next;
            ListNode mid = list2;
            while (mid.next != null) mid = mid.next;
            left.next = list2; mid.next = right.next; right.next = null;

            return list1;
        }
    }
}
