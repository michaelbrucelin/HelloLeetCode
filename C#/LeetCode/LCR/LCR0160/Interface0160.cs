using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0160
{
    /// <summary>
    /// Your MedianFinder object will be instantiated and called as such:
    /// MedianFinder obj = new MedianFinder();
    /// obj.AddNum(num);
    /// double param_2 = obj.FindMedian();
    /// </summary>
    public interface Interface0160
    {
        /** initialize your data structure here. */
        // public MedianFinder(){ }

        public void AddNum(int num);

        public double FindMedian();
    }
}
