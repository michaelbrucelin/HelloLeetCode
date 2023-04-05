using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1502
{
    public class Solution1502 : Interface1502
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            Array.Sort(arr);
            int diff = arr[1] - arr[0];  // 题目保证数组中至少两个元素
            for (int i = 2; i < arr.Length; i++)
                if (arr[i] - arr[i - 1] != diff) return false;

            return true;
        }
    }
}
