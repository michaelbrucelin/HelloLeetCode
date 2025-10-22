using LeetCode.QuestionBank.Question3346;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3347
{
    public class Solution3347 : Interface3347
    {
        /// <summary>
        /// 题目完全同Solution3346，连输入的数据范围都一致。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="numOperations"></param>
        /// <returns></returns>
        public int MaxFrequency(int[] nums, int k, int numOperations)
        {
            return (new Solution3346()).MaxFrequency(nums, k, numOperations);
        }
    }
}
