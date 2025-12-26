using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0352
{
    /// <summary>
    /// Your SummaryRanges object will be instantiated and called as such:
    /// SummaryRanges obj = new SummaryRanges();
    /// obj.AddNum(value);
    /// int[][] param_2 = obj.GetIntervals();
    /// </summary>
    public interface Interface0352
    {
        // public SummaryRanges(){ }

        public void AddNum(int value);

        public int[][] GetIntervals();
    }
}
