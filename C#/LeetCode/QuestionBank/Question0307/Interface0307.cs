using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0307
{
    /// <summary>
    /// Your NumArray object will be instantiated and called as such:
    /// NumArray obj = new NumArray(nums);
    /// obj.Update(index,val);
    /// int param_2 = obj.SumRange(left,right);
    /// </summary>
    public interface Interface0307
    {
        // public NumArray(int[] nums)
        // {
        // }

        public void Update(int index, int val);

        public int SumRange(int left, int right);
    }
}
