using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0295
{
    /// <summary>
    /// Your MedianFinder object will be instantiated and called as such:
    /// MedianFinder obj = new MedianFinder();
    /// obj.AddNum(num);
    /// double param_2 = obj.FindMedian();
    /// </summary>
    public interface Interface0295
    {
        // public MedianFinder(){ }

        public void AddNum(int num);

        public double FindMedian();
    }
}
