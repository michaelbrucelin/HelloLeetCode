using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0341
{
    public class Solution0341
    {
    }

    public class NestedIterator : Interface0341
    {
        public NestedIterator(IList<NestedInteger> nestedList)
        {
            stack = new Stack<(IList<NestedInteger>, int)>();
            list = nestedList;
            ptr = 0;
        }

        private Stack<(IList<NestedInteger>, int)> stack;
        private IList<NestedInteger> list;
        private int ptr;

        public bool HasNext()
        {
            while ((ptr == list.Count && stack.Count > 0) || (ptr < list.Count && !list[ptr].IsInteger()))
            {
                if (ptr == list.Count && stack.Count > 0)
                {
                    (list, ptr) = stack.Pop();
                }
                else  // if (ptr < list.Count && !list[ptr].IsInteger())
                {
                    stack.Push((list, ptr + 1));
                    list = list[ptr].GetList();
                    ptr = 0;
                }
            }

            return ptr < list.Count;
        }

        public int Next()
        {
            return list[ptr++].GetInteger();
        }
    }
}
