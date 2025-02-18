using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2080
{
    /// <summary>
    /// Your RangeFreqQuery object will be instantiated and called as such:
    /// RangeFreqQuery obj = new RangeFreqQuery(arr);
    /// int param_1 = obj.Query(left,right,value);
    /// </summary>
    public interface Interface2080
    {
        // public RangeFreqQuery(int[] arr)
        // {
        // }

        public int Query(int left, int right, int value);
    }
}
