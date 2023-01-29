using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0225
{
    /// <summary>
    /// Your MyStack object will be instantiated and called as such:
    /// MyStack obj = new MyStack();
    /// obj.Push(x);
    /// int param_2 = obj.Pop();
    /// int param_3 = obj.Top();
    /// bool param_4 = obj.Empty();
    /// </summary>
    public interface Interface0225
    {
        public void Push(int x);

        public int Pop();

        public int Top();

        public bool Empty();
    }
}
