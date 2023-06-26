using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2485
{
    public class Solution2485_dial : Interface2485
    {
        public int PivotInteger(int n)
        {
            Dictionary<int, int> map = new Dictionary<int, int>() { { 1, 1 }, { 8, 6 }, { 49, 35 }, { 288, 204 } };

            return map.ContainsKey(n) ? map[n] : -1;
        }
    }
}
