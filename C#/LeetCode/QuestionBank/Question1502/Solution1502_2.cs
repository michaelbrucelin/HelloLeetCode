using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1502
{
    public class Solution1502_2 : Interface1502
    {
        /// <summary>
        /// 分析
        /// 1. 一次遍历找出数组的最大值，最小值，并将数组转为Hash表
        /// 2. 由最大值最小值可以得出公差
        ///     公差不是整数，false
        ///     公差为0，true
        ///     公差为d，也就确定了数组中的每一项：min, min+d, min+2d, ...，检查每一项在不在Hash表中
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            int min = arr[0], max = arr[0], len = arr.Length;
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < len; i++)
            {
                min = Math.Min(min, arr[i]);
                max = Math.Max(max, arr[i]);
                set.Add(arr[i]);
            }

            if (max == min) return true;
            var info = Math.DivRem(max - min, len - 1);  // 题目保证数组中至少两个元素
            if (info.Remainder != 0) return false;
            int diff = info.Quotient;
            for (int i = 0; i < len - 2; i++) if (!set.Contains(min += diff)) return false;

            return true;
        }
    }
}
