using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0689
{
    public class Solution0689 : Interface0689
    {
        /// <summary>
        /// 滑动窗口 + 两轮DP
        /// 1. 通过滑动窗口记录以第n项结尾的长度为k的子数组的最大值，记录到一个数组中
        /// 2. 得出数组的前n项中长度为k的子数组的最大和，并记录到一个数组中
        /// 3. 第1轮dp，得出得出数组的前n项中两组长度为k的子数组的最大和，并记录到一个数组中
        /// 4. 第2轮dp，得出得出数组的前n项中三组长度为k的子数组的最大和，并记录到一个数组中
        /// 
        /// 每一部分的数组临时结果，数组都可以更小，但是需要做id变换，这里并没有那么做
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
        {
            // 长度为k的子数组的和
            int len = nums.Length;
            int[] sumk = new int[len];
            int sum = 0;
            for (int i = 0; i < k; i++) sum += nums[i]; sumk[k - 1] = sum;
            for (int i = k; i < len; i++) { sum -= nums[i - k]; sum += nums[i]; sumk[i] = sum; }

            // 1k结果
            int[,] max1k = new int[len, 2];
            max1k[k - 1, 0] = sumk[k - 1]; max1k[k - 1, 1] = 0;
            for (int i = k; i < len - (k * 2); i++)
            {
                if (sumk[i] > max1k[i - 1, 0]) { max1k[i, 0] = sumk[i]; max1k[i, 1] = i - k + 1; }
                else { max1k[i, 0] = max1k[i - 1, 0]; max1k[i, 1] = max1k[i - 1, 1]; }
            }

            // 2k结果
            int[,] max2k = new int[len, 3];
            max2k[k * 2 - 1, 0] = sumk[k - 1] + sumk[k * 2 - 1]; max2k[k * 2 - 1, 1] = 0; max2k[k * 2 - 1, 2] = k;
            for (int i = k * 2; i < len - k; i++)
            {
                if ((sum = sumk[i] + max1k[i - k, 0]) > max2k[i - 1, 0]) { max2k[i, 0] = sum; max2k[i, 1] = max1k[i - k, 1]; max2k[i, 2] = i - k + 1; }
                else { max2k[i, 0] = max2k[i - 1, 0]; max2k[i, 1] = max2k[i - 1, 1]; max2k[i, 2] = max2k[i - 1, 2]; }
            }

            // 3k结果
            int[,] max3k = new int[len, 4];
            max3k[k * 3 - 1, 0] = sumk[k - 1] + sumk[k * 2 - 1] + sumk[k * 3 - 1]; max3k[k * 3 - 1, 1] = 0; max3k[k * 3 - 1, 2] = k; max3k[k * 3 - 1, 3] = k * 2;
            for (int i = k * 3; i < len; i++)
            {
                if ((sum = sumk[i] + max2k[i - k, 0]) > max3k[i - 1, 0]) { max3k[i, 0] = sum; max3k[i, 1] = max2k[i - k, 1]; max3k[i, 2] = max2k[i - k, 2]; max3k[i, 3] = i - k + 1; }
                else { max3k[i, 0] = max3k[i - 1, 0]; max3k[i, 1] = max3k[i - 1, 1]; max3k[i, 2] = max3k[i - 1, 2]; max3k[i, 3] = max3k[i - 1, 3]; }
            }

            // 结果
            int maxid = k * 3 - 1;
            for (int i = k * 3; i < len; i++) if (max3k[i, 0] > max3k[maxid, 0]) maxid = i;
            int[] result = new int[] { max3k[maxid, 1], max3k[maxid, 2], max3k[maxid, 3] };
            return result;
        }
    }
}
