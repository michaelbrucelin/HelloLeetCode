using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0301
{
    /// <summary>
    /// Your TripleInOne object will be instantiated and called as such:
    /// TripleInOne obj = new TripleInOne(stackSize);
    /// obj.Push(stackNum,value);
    /// int param_2 = obj.Pop(stackNum);
    /// int param_3 = obj.Peek(stackNum);
    /// bool param_4 = obj.IsEmpty(stackNum);
    /// </summary>
    public interface Interface0301
    {
        public void Push(int stackNum, int value);

        public int Pop(int stackNum);

        public int Peek(int stackNum);

        public bool IsEmpty(int stackNum);
    }
}
