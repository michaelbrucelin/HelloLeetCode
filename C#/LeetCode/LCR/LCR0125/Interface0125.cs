using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0125
{
    /// <summary>
    /// Your CQueue object will be instantiated and called as such:
    /// CQueue obj = new CQueue();
    /// obj.AppendTail(value);
    /// int param_2 = obj.DeleteHead();
    /// </summary>
    public interface Interface0125
    {
        // public CQueue() { }

        public void AppendTail(int value);

        public int DeleteHead();
    }
}
