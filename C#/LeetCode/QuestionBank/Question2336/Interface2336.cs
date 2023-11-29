using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2336
{
    /// <summary>
    /// Your SmallestInfiniteSet object will be instantiated and called as such:
    /// SmallestInfiniteSet obj = new SmallestInfiniteSet();
    /// int param_1 = obj.PopSmallest();
    /// obj.AddBack(num);
    /// </summary>
    public interface Interface2336
    {
        public int PopSmallest();

        public void AddBack(int num);
    }
}
