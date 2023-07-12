using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1047
{
    public class Solution1047_2 : Interface1047
    {
        /// <summary>
        /// 链表操作
        /// 逻辑同Solution1047中的数组操作
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicates(string s)
        {
            ListNode<char> dummy = new ListNode<char>('A');
            ListNode<char> ptr = dummy;
            for (int i = 0; i < s.Length; i++)
            {
                ListNode<char> node = new ListNode<char>(s[i]);
                ptr.next = node; node.prev = ptr; ptr = node;
            }
            ListNode<char> _dummy = new ListNode<char>('Z');
            ptr.next = _dummy; _dummy.prev = ptr;

            ptr = dummy.next;
            while (ptr.next != null)
            {
                if (ptr.value == ptr.next.value)
                {
                    ptr.prev.next = ptr.next.next;
                    ptr.next.next.prev = ptr.prev;
                    ptr = ptr.prev;
                }
                else
                {
                    ptr = ptr.next;
                }
            }

            StringBuilder result = new StringBuilder();
            ptr = dummy.next;
            while (ptr.next != null)
            {
                result.Append(ptr.value); ptr = ptr.next;
            }

            return result.ToString();
        }

        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.value = value;
            }

            public T value { get; set; }
            public ListNode<T> prev { get; set; }
            public ListNode<T> next { get; set; }
        }
    }
}
