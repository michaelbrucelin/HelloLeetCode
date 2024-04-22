using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0041
{
    public class Solution0041
    {
    }

    /// <summary>
    /// 使用队列记录窗口
    /// </summary>
    public class MovingAverage : Interface0041
    {
        public MovingAverage(int size)
        {
            this.size = size;
            sum = 0;
            window = new Queue<int>();
        }

        private Queue<int> window;
        private int size;
        private double sum;

        public double Next(int val)
        {
            window.Enqueue(val);
            sum += val;
            if (window.Count > size)
            {
                sum -= window.Dequeue();
            }

            return sum / window.Count;
        }
    }
}
