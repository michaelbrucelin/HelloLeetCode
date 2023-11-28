using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1670
{
    /// <summary>
    /// Your FrontMiddleBackQueue object will be instantiated and called as such:
    /// FrontMiddleBackQueue obj = new FrontMiddleBackQueue();
    /// obj.PushFront(val);
    /// obj.PushMiddle(val);
    /// obj.PushBack(val);
    /// int param_4 = obj.PopFront();
    /// int param_5 = obj.PopMiddle();
    /// int param_6 = obj.PopBack();
    /// </summary>
    public interface Interface1670
    {
        public void PushFront(int val);

        public void PushMiddle(int val);

        public void PushBack(int val);

        public int PopFront();

        public int PopMiddle();

        public int PopBack();
    }
}
