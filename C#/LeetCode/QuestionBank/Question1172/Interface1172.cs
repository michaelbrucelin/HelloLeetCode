using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1172
{
    /// <summary>
    /// Your DinnerPlates object will be instantiated and called as such:
    /// DinnerPlates obj = new DinnerPlates(capacity);
    /// obj.Push(val);
    /// int param_2 = obj.Pop();
    /// int param_3 = obj.PopAtStack(index);
    /// </summary>
    public interface Interface1172
    {
        public void Push(int val);

        public int Pop();

        public int PopAtStack(int index);
    }
}
