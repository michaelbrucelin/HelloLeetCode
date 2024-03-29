using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0069
{
    public class Solution0069_2 : Interface0069
    {
        /// <summary>
        /// 二分
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int PeakIndexInMountainArray(int[] arr)
        {
            int left = 1, right = arr.Length - 2, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (arr[mid] < arr[mid + 1]) left = mid + 1;
                else if (arr[mid] < arr[mid - 1]) right = mid - 1;
                else return mid;
            }

            throw new Exception("logic error.");
        }
    }
}
