using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0284
{
    public class Solution0284
    {
    }

    /// <summary>
    /// 模拟
    /// </summary>
    public class PeekingIterator : Interface0284
    {
        public PeekingIterator(IEnumerator<int> iterator)
        {
            list = [];
            do { list.Add(iterator.Current); } while (iterator.MoveNext());
            ptr = 0;
        }

        private List<int> list;
        private int ptr;

        public int Peek()
        {
            return list[ptr];
        }

        public int Next()
        {
            return list[ptr++];
        }

        public bool HasNext()
        {
            return ptr < list.Count;
        }
    }
}
