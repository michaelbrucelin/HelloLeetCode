using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1287
{
    public class Solution1287_2 : Interface1287
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindSpecialInteger(int[] arr)
        {
            int ptr = 0, _ptr, len = arr.Length, p25 = arr.Length >> 2;
            while (ptr < len)
            {
                _ptr = BinarySearch(arr, ptr, arr[ptr]);
                if (_ptr == -1 || _ptr - ptr > p25) return arr[ptr];
                ptr = _ptr;
            }

            throw new Exception("TestCase Or Code Logic Error.");  // 题目保证了一定有唯一解
        }

        /// <summary>
        /// 返回数组中第一个大于target的元素的索引
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearch(int[] arr, int start, int target)
        {
            int result = -1, low = start, high = arr.Length - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (arr[mid] > target)
                {
                    result = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }
    }
}
