using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1609
{
    /// <summary>
    /// Your Operations object will be instantiated and called as such:
    /// Operations obj = new Operations();
    /// int param_1 = obj.Minus(a,b);
    /// int param_2 = obj.Multiply(a,b);
    /// int param_3 = obj.Divide(a,b);
    /// </summary>
    public interface Interface1609
    {
        // public Operations(){ }

        public int Minus(int a, int b);

        public int Multiply(int a, int b);

        public int Divide(int a, int b);
    }
}
