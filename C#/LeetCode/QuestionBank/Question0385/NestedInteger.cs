using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0385
{
    /// <summary>
    /// This is the interface that allows for creating nested lists.
    /// You should not implement it, or speculate about its implementation
    /// </summary>
    public class NestedInteger
    {
        // Constructor initializes an empty nested list.
        public NestedInteger()
        {
        }

        // Constructor initializes a single integer.
        public NestedInteger(int value)
        {
            throw new NotImplementedException();
        }

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger()
        {
            throw new NotImplementedException();
        }

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger()
        {
            throw new NotImplementedException();
        }

        // Set this NestedInteger to hold a single integer.
        public void SetInteger(int value)
        {
            throw new NotImplementedException();
        }

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        public void Add(NestedInteger ni)
        {
            throw new NotImplementedException();
        }

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
