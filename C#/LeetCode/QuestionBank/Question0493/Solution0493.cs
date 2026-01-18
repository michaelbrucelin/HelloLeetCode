using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0493
{
    public class Solution0493 : Interface0493
    {
        /// <summary>
        /// 归并排序
        /// 每一轮归并排序的同时使用双指针计数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ReversePairs(int[] nums)
        {
            int result = 0;
            merge(0, nums.Length - 1);
            return result;

            int[] merge(int left, int right)
            {
                if (left == right) return [nums[left]];

                int mid = left + ((right - left) >> 1);
                int[] larr = merge(left, mid);
                int[] rarr = merge(mid + 1, right);

                int pl = -1, pr = 0, lenl = larr.Length, lenr = rarr.Length;
                while (++pl < lenl)
                {
                    while (pr < lenr && (1L * rarr[pr] << 1) < larr[pl]) pr++;
                    result += pr;
                }

                int[] lrarr = new int[right - left + 1];
                int idx = 0; pl = pr = 0;
                while (pl < lenl && pr < lenr) lrarr[idx++] = larr[pl] <= rarr[pr] ? larr[pl++] : rarr[pr++];
                while (pl < lenl) lrarr[idx++] = larr[pl++];
                while (pr < lenr) lrarr[idx++] = rarr[pr++];

                return lrarr;
            }
        }
    }
}
