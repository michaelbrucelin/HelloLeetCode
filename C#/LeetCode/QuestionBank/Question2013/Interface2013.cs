using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2013
{
    /// <summary>
    /// Your DetectSquares object will be instantiated and called as such:
    /// DetectSquares obj = new DetectSquares();
    /// obj.Add(point);
    /// int param_2 = obj.Count(point);
    /// </summary>
    public interface Interface2013
    {
        // public DetectSquares(){ }

        public void Add(int[] point);

        public int Count(int[] point);
    }
}
