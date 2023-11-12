using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode.QuestionBank.Question0715
{
    /// <summary>
    /// Your RangeModule object will be instantiated and called as such:
    /// RangeModule obj = new RangeModule();
    /// obj.AddRange(left,right);
    /// bool param_2 = obj.QueryRange(left,right);
    /// obj.RemoveRange(left,right);
    /// </summary>
    public interface Interface0715
    {
        public void AddRange(int left, int right);

        public bool QueryRange(int left, int right);

        public void RemoveRange(int left, int right);
    }
}
