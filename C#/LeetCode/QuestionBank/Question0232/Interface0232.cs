using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0232
{
    /// <summary>
    /// Your MyQueue object will be instantiated and called as such:
    /// MyQueue obj = new MyQueue();
    /// obj.Push(x);
    /// int param_2 = obj.Pop();
    /// int param_3 = obj.Peek();
    /// bool param_4 = obj.Empty();
    /// </summary>
    public interface Interface0232
    {
        public void Push(int x);

        public int Pop();

        public int Peek();

        public bool Empty();
    }
}
