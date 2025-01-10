using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1588
{
    public class Solution1588_2 : Interface1588
    {
        /// <summary>
        /// 贡献法
        /// 对于数组第i个元素，由这个元素组成的长度为奇数的子数组，左侧和右侧的元素数量同奇同偶
        /// 左侧共有lcnt = i       个元素，奇数长度有 (lcnt+1)/2 个，偶数长度有 lcnt/2+1 个
        /// 右侧共有rcnt = len-i-1 个元素，奇数长度有 (rcnt+1)/2 个，偶数长度有 rcnt/2+1 个
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int SumOddLengthSubarrays(int[] arr)
        {
            int result = 0, lcnt, rcnt, len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                lcnt = i;
                rcnt = len - i - 1;
                result += arr[i] * (((lcnt + 1) / 2) * ((rcnt + 1) / 2) + (lcnt / 2 + 1) * (rcnt / 2 + 1));
            }

            return result;
        }
    }
}
