using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2276
{
    /// <summary>
    /// Your CountIntervals object will be instantiated and called as such:
    /// CountIntervals obj = new CountIntervals();
    /// obj.Add(left,right);
    /// int param_2 = obj.Count();
    /// </summary>
    public interface Interface2276
    {
        public void Add(int left, int right);

        public int Count();
    }
}
