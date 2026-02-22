using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0341
{
    /// <summary>
    /// Your NestedIterator will be called like this:
    /// NestedIterator i = new NestedIterator(nestedList);
    /// while (i.HasNext()) v[f()] = i.Next();
    /// </summary>
    public interface Interface0341
    {
        // public NestedIterator(IList<NestedInteger> nestedList) { }

        public bool HasNext();

        public int Next();
    }
}
