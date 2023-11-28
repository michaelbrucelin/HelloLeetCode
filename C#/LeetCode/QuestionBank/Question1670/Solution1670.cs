using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1670
{
    public class Solution1670
    {
    }

    /// <summary>
    /// 用一个List模拟
    /// </summary>
    public class FrontMiddleBackQueue : Interface1670
    {
        public FrontMiddleBackQueue()
        {
            list = new List<int>();
        }

        private List<int> list;

        public int PopBack()
        {
            if (list.Count == 0) return -1;

            int val = list[^1];
            list.RemoveAt(list.Count - 1);

            return val;
        }

        public int PopFront()
        {
            if (list.Count == 0) return -1;

            int val = list[0];
            list.RemoveAt(0);

            return val;
        }

        public int PopMiddle()
        {
            if (list.Count == 0) return -1;

            int index = (list.Count - 1) >> 1;
            int val = list[index];
            list.RemoveAt(index);

            return val;
        }

        public void PushBack(int val)
        {
            list.Add(val);
        }

        public void PushFront(int val)
        {
            list.Insert(0, val);
        }

        public void PushMiddle(int val)
        {
            list.Insert(list.Count >> 1, val);
        }
    }
}
