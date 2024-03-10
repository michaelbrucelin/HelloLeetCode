using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0806
{
    public class Test0806
    {
        public void Test()
        {
            Interface0806 solution = new Solution0806_2();
            IList<int> A, B, C;

            // 1. 
            A = new List<int>() { 0 }; B = new List<int>(); C = new List<int>();
            solution.Hanota(A, B, C);

            // 2. 
            A = new List<int>() { 1, 0 }; B = new List<int>(); C = new List<int>();
            solution.Hanota(A, B, C);

            // 3. 
            A = new List<int>() { 2, 1, 0 }; B = new List<int>(); C = new List<int>();
            solution.Hanota(A, B, C);

            // 4. 
            A = new List<int>() { 3, 2, 1, 0 }; B = new List<int>(); C = new List<int>();
            solution.Hanota(A, B, C);
        }
    }
}
