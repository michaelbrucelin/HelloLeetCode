using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0852
{
    public class Solution0852 : Interface0852
    {
        /// <summary>
        /// 二分
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int PeakIndexInMountainArray(int[] arr)
        {
            if (arr.Length == 3) return 1;

            int left = 1, right = arr.Length - 2, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                switch ((arr[mid] - arr[mid - 1], arr[mid] - arr[mid + 1]))
                {
                    case ( > 0, < 0): left = mid + 1; break;
                    case ( < 0, > 0): right = mid - 1; break;
                    default: return mid;
                }
            }

            return -1;
        }
    }
}
