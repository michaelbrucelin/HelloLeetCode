using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3487
{
    public class Solution3487_2 : Interface3487
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSum(int[] nums)
        {
            bool[] mask = new bool[201];
            foreach (int num in nums) mask[num + 100] = true;

            int result = 0;
            for (int i = 200; i > 100; i--) if (mask[i]) result += i - 100;
            if (result > 0) return result;
            if (mask[100]) return 0;
            for (int i = 99; i > -1; i--) if (mask[i]) return i - 100;

            throw new Exception("logic error");
        }
    }
}
