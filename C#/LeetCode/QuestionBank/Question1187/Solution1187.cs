using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1187
{
    public class Solution1187 : Interface1187
    {
        /// <summary>
        /// 贪心
        /// 只是一个思路，没有严格的证明这样做是正确的
        /// 1. arr2升序排列，方便一会从其中找元素
        /// 2. arr1中的每对相邻的非递增元素(x,y), x_id + 1 = y_id, x >= y，有3种可能的调整
        ///     2.1. 让x变小
        ///     2.2. 让y变大
        ///     2.3. 将x, y都给换了
        /// 3. 这里贪心是的核心是：
        ///     3.1. 从前向后寻找相邻的非递增元素对，
        ///     3.2. 按照上面的3种调整方式（2.1 -> 2.2 -> 2.3的顺序）调整
        ///     3.3. 尽可能让调整后的元素更小（这样后面调整的空间就更大，arr2中剩余可用的元素也更多）
        /// 
        /// 思路不对，未完成
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int MakeArrayIncreasing(int[] arr1, int[] arr2)
        {
            Array.Sort(arr2);
            int result = 0, len = arr1.Length, p1 = 1, p2 = 0, _p2;  // p1,p2分别是arr1与arr2的索引
            while (p1 < len)
            {
                if (arr1[p1] > arr1[p1 - 1]) p1++;
                else
                {
                    _p2 = p1 - 2 < 0 ? p2 : BinarySearch(arr2, p2, arr1[p1 - 2]);
                    if (_p2 != -1 && arr2[_p2] < arr1[p1])
                    {
                        p2 = _p2 + 1; p1++; result++; continue;
                    }
                    _p2 = BinarySearch(arr2, p2, arr1[p1 - 1]);
                    if (_p2 != -1 && (p1 + 1 == len || (p1 + 1 < len && arr2[_p2] < arr1[p1 + 1])))
                    {
                        p2 = _p2 + 1; p1++; result++; continue;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 查找大于目标值的最小值的id
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
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
                else  // if (arr[mid] <= target)
                {
                    low = mid + 1;
                }
            }

            return result;
        }
    }
}
