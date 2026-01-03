using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0622
{
    /// <summary>
    /// Your MyCircularQueue object will be instantiated and called as such:
    /// MyCircularQueue obj = new MyCircularQueue(k);
    /// bool param_1 = obj.EnQueue(value);
    /// bool param_2 = obj.DeQueue();
    /// int param_3 = obj.Front();
    /// int param_4 = obj.Rear();
    /// bool param_5 = obj.IsEmpty();
    /// bool param_6 = obj.IsFull();
    /// </summary>
    public interface Interface0622
    {
        // public MyCircularQueue(int k) { }

        public bool EnQueue(int value);

        public bool DeQueue();

        public int Front();

        public int Rear();

        public bool IsEmpty();

        public bool IsFull();
    }
}
