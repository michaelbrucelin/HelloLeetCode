using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1622
{
    /// <summary>
    /// Your Fancy object will be instantiated and called as such:
    /// Fancy obj = new Fancy();
    /// obj.Append(val);
    /// obj.AddAll(inc);
    /// obj.MultAll(m);
    /// int param_4 = obj.GetIndex(idx);
    /// </summary>
    public interface Interface1622
    {
        // public Fancy() { }

        public void Append(int val);

        public void AddAll(int inc);

        public void MultAll(int m);

        public int GetIndex(int idx);
    }
}
