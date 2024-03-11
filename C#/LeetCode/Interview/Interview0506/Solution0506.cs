using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0506
{
    public class Solution0506 : Interface0506
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int ConvertInteger(int A, int B)
        {
            if (A == B) return 0;
            int result = 0;
            for (int i = 0; i < 32; i++) if (((A >> i) & 1) != ((B >> i) & 1)) result++;

            return result;
        }
    }
}
