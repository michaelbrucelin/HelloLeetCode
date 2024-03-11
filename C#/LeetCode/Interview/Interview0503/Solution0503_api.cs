using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0503
{
    public class Solution0503_api : Interface0503
    {
        public int ReverseBits(int num)
        {
            int[] lens = Convert.ToString(num, 2).Split('0').Select(s => s.Length).ToArray();
            int result = lens[0];
            for (int i = 1; i < lens.Length; i++) result = Math.Max(result, lens[i - 1] + lens[i]);
            result++;

            return result > 32 ? 32 : result;
        }
    }
}
