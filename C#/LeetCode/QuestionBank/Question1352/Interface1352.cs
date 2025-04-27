using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1352
{
    /// <summary>
    /// Your ProductOfNumbers object will be instantiated and called as such:
    /// ProductOfNumbers obj = new ProductOfNumbers();
    /// obj.Add(num);
    /// int param_2 = obj.GetProduct(k);
    /// </summary>
    public interface Interface1352
    {
        // public ProductOfNumbers() { }

        public void Add(int num);

        public int GetProduct(int k);
    }
}
