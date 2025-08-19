using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0148
{
    public class Solution0148 : Interface0148
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            List<ListNode> list = new List<ListNode>();
            ListNode ptr = head;
            while (ptr != null) { list.Add(ptr); ptr = ptr.next; }
            list.Sort((x, y) => x.val - y.val);
            int cnt = list.Count;
            list.Add(null);
            for (int i = 0; i < cnt; i++) list[i].next = list[i + 1];

            return list[0];
        }

        /// <summary>
        /// 逻辑与SortList()一样，排序改为计数排序
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList2(ListNode head)
        {
            if (head == null || head.next == null) return head;

            const int offset = 100000;
            List<ListNode>[] list = new List<ListNode>[200001];
            ListNode ptr = head;
            while (ptr != null)
            {
                if (list[ptr.val + offset] == null) list[ptr.val + offset] = [];
                list[ptr.val + offset].Add(ptr);
                ptr = ptr.next;
            }

            ListNode dummy = new ListNode();
            ptr = dummy;
            for (int i = 0; i < 200001; i++) if (list[i] != null) foreach (ListNode item in list[i])
                    {
                        ptr.next = item; ptr = ptr.next;
                    }
            ptr.next = null;

            return dummy.next;
        }

        /// <summary>
        /// 逻辑与SortList2()一样，先判断值的范围
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList3(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode ptr = head;
            int min = int.MaxValue, max = int.MinValue;
            while (ptr != null) { min = Math.Min(min, ptr.val); max = Math.Max(max, ptr.val); ptr = ptr.next; }
            int offset = -min;
            List<ListNode>[] list = new List<ListNode>[max - min + 1];
            ptr = head;
            while (ptr != null)
            {
                if (list[ptr.val + offset] == null) list[ptr.val + offset] = [];
                list[ptr.val + offset].Add(ptr);
                ptr = ptr.next;
            }

            ListNode dummy = new ListNode();
            ptr = dummy;
            for (int i = 0; i < list.Length; i++) if (list[i] != null) foreach (ListNode item in list[i])
                    {
                        ptr.next = item; ptr = ptr.next;
                    }
            ptr.next = null;

            return dummy.next;
        }
    }
}
