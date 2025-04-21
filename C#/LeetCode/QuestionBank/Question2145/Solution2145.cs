using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2145
{
    public class Solution2145 : Interface2145
    {
        /// <summary>
        /// 差分数组
        /// 数组还原找出最大值与最小值的差即可
        /// </summary>
        /// <param name="differences"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public int NumberOfArrays(int[] differences, int lower, int upper)
        {
            long min = 0, max = 0, num = 0, len = differences.Length;
            for (int i = 0; i < len; i++)
            {
                num += differences[i];
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }

            long result = max - min, step = (long)upper - lower;
            return result <= step ? (int)(step - result + 1) : 0;
        }

        /// <summary>
        /// 逻辑完全同NumberOfArrays()，增加了剪枝
        /// </summary>
        /// <param name="differences"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public int NumberOfArrays2(int[] differences, int lower, int upper)
        {
            long min = 0, max = 0, num = 0, step = (long)upper - lower, len = differences.Length;
            for (int i = 0; i < len; i++)
            {
                num += differences[i];
                min = Math.Min(min, num);
                max = Math.Max(max, num);
                if (max - min > step) return 0; // 剪枝
            }

            return (int)(step - (max - min) + 1);
        }
    }
}
