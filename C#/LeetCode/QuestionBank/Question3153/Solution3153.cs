using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3153
{
    public class Solution3153 : Interface3153
    {
        /// <summary>
        /// 排列组合
        /// 不需要每两个数字去比较，单独计算每一位即可
        /// 1. 统计出每一位中 0 - 9 的数目，然后遍历计算
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long SumDigitDifferences(int[] nums)
        {
            List<int[]> dstb = new List<int[]>();
            for (int i = 0, div, len = nums.Length; i <= 9; i++)
            {
                div = (int)Math.Pow(10, i);
                if (nums[0] < div) break;
                dstb.Add(new int[10]);
                for (int j = 0; j < len; j++) dstb[i][nums[j] / div % 10]++;
            }

            long result = 0;
            foreach (int[] arr in dstb)
            {
                for (int i = 0; i < 10; i++) for (int j = i + 1; j < 10; j++) result += 1L * arr[i] * arr[j];
            }

            return result;
        }

        public long SumDigitDifferences2(int[] nums)
        {
            List<int[]> dstb = new List<int[]>();
            int len = nums.Length;
            for (int i = 0, div; i <= 9; i++)
            {
                div = (int)Math.Pow(10, i);
                if (nums[0] < div) break;
                dstb.Add(new int[10]);
                for (int j = 0; j < len; j++) dstb[i][nums[j] / div % 10]++;
            }

            long result = 0, _result;
            foreach (int[] arr in dstb)
            {
                _result = 0;
                for (int i = 0; i < 10; i++) _result += 1L * arr[i] * (len - arr[i]);
                result += _result >> 1;
            }

            return result;
        }
    }
}
