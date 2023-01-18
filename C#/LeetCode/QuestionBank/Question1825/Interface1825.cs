using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1825
{
    /// <summary>
    /// Your MKAverage object will be instantiated and called as such:
    /// MKAverage obj = new MKAverage(m, k);
    /// obj.AddElement(num);
    /// int param_2 = obj.CalculateMKAverage();
    /// </summary>
    public interface Interface1825
    {
        //public MKAverage(int m, int k)
        //{
        //}

        public void AddElement(int num);

        public int CalculateMKAverage();
    }
}
