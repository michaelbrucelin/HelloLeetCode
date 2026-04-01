using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2023
{
    public class Solution2023 : Interface2023
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int NumOfPairs(string[] nums, string target)
        {
            int result = 0, len = nums.Length, lent = target.Length, leni, lenj, p;
            for (int i = 0; i < len; i++) for (int j = 0; j < len; j++) if (j != i)
                    {
                        if ((leni = nums[i].Length) + (lenj = nums[j].Length) != lent) continue;
                        p = 0;
                        for (int k = 0; k < leni; k++) if (nums[i][k] != target[p++]) goto CONTINUE;
                        for (int k = 0; k < lenj; k++) if (nums[j][k] != target[p++]) goto CONTINUE;
                        result++;
                    CONTINUE:;
                    }

            return result;
        }
    }
}
