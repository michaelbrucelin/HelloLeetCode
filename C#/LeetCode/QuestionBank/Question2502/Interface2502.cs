using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2502
{
    /// <summary>
    /// Your Allocator object will be instantiated and called as such:
    /// Allocator obj = new Allocator(n);
    /// int param_1 = obj.Allocate(size,mID);
    /// int param_2 = obj.FreeMemory(mID);
    /// </summary>
    public interface Interface2502
    {
        // public Allocator(int n) { }

        public int Allocate(int size, int mID);

        public int FreeMemory(int mID);
    }
}
