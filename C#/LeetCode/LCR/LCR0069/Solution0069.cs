using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0069
{
    public class Solution0069 : Interface0069
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int PeakIndexInMountainArray(int[] arr)
        {
            for (int i = 1; i < arr.Length - 1; i++) if (arr[i] > arr[i + 1]) return i;

            throw new Exception("logic error.");
        }
    }
}
