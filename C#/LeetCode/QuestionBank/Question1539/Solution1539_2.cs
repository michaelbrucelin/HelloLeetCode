using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1539
{
    public class Solution1539_2 : Interface1539
    {
        /// <summary>
        /// 二分法
        /// cnt = arr[i] - i - 1，到arr[i]，缺失了x个整数，
        /// 二分法可以找到第k个缺失的数字在arr[i]与arr[i+1]之间，找到i即可
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthPositive(int[] arr, int k)
        {
            if (arr[0] > k) return k;
            int id = -1, left = 0, right = arr.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (arr[mid] - mid - 1 < k)
                {
                    id = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return k + id + 1;
        }
    }
}
