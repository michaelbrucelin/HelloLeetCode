using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1670
{
    public class Solution1670_2
    {
    }

    /// <summary>
    /// 用两个双向链表模拟
    /// 第1个链表的头部是头部，第2个链表的尾部是尾部，第1个链表的尾部和第2个链表的头部是中部
    /// 每次添加或移除元素时，需要保证两个链表元素的数量相等，或者后面比前面多1个元素
    /// </summary>
    public class FrontMiddleBackQueue_2 : Interface1670
    {
        public FrontMiddleBackQueue_2()
        {
            head = new LinkedList<int>();
            tail = new LinkedList<int>();
        }

        LinkedList<int> head, tail;

        public int PopBack()
        {
            int val = -1;
            if (tail.Count > 0)
            {
                val = tail.Last(); tail.RemoveLast();
                if (head.Count == tail.Count + 1)
                {
                    int temp = head.Last(); head.RemoveLast(); tail.AddFirst(temp);
                }
            }

            return val;
        }

        public int PopFront()
        {
            int val = -1;
            if (head.Count > 0)
            {
                val = head.First(); head.RemoveFirst();
                if (tail.Count == head.Count + 2)
                {
                    int temp = tail.First(); tail.RemoveFirst(); head.AddLast(temp);
                }
            }
            else if (tail.Count > 0)
            {
                val = tail.First(); tail.RemoveFirst();
            }

            return val;
        }

        public int PopMiddle()
        {
            int val;
            if (head.Count == 0 && tail.Count == 0) val = -1;
            else if (head.Count == tail.Count)
            {
                val = head.Last(); head.RemoveLast();
            }
            else  // if (head.Count < tail.Count)
            {
                val = tail.First(); tail.RemoveFirst();
            }

            return val;
        }

        public void PushBack(int val)
        {
            tail.AddLast(val);
            if (tail.Count == head.Count + 2)
            {
                int temp = tail.First(); tail.RemoveFirst(); head.AddLast(temp);
            }
        }

        public void PushFront(int val)
        {
            if (head.Count == 0 && tail.Count == 0) tail.AddFirst(val);
            else
            {
                head.AddFirst(val);
                if (head.Count == tail.Count + 1)
                {
                    int temp = head.Last(); head.RemoveLast(); tail.AddFirst(temp);
                }
            }
        }

        public void PushMiddle(int val)
        {
            if (head.Count == tail.Count) tail.AddFirst(val); else head.AddLast(val);
        }
    }
}
