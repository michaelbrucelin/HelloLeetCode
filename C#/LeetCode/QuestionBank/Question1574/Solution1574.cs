using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1574
{
    public class Solution1574 : Interface1574
    {
        /// <summary>
        /// 分析
        /// 仔细分析一下，由于删除的是子数组（连续），而不是子序列（离散），所以指引删除前缀、删除后缀与删除中间一段三种可能
        /// 删除前缀与删除后缀就简单了，主要是删除中间一段需要分析一下，可以采用下面的方式来实现
        /// 下面以[1,2,3,10,4,2,3,5]为例来解释
        /// 1. 从前向后找出最长的非递减前缀[1,2,3,10]
        /// 2. 从后向前找出最长的非递减后缀[2,3,5]
        /// 3. 中间的部分[4]是一定要删除的，而且两边部分都有单调性，可以使用二分法
        /// 4. 下面就进入暴力部分
        ///     4.1. 左边一个不删除，即找出右边第一个大于等于左边最后一个值的位置（二分法）
        ///     4.2. 左边删除1个...
        ///     4.3. ...
        ///     注意：1. 暴力左边还是右边，要看那边长度更小，即小表驱动大表
        ///           2. 删除前缀与删除后缀其实已经包含在这里边了
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindLengthOfShortestSubarray(int[] arr)
        {
            int len = arr.Length; int left = 0, right = len - 1;
            while (left + 1 <= right && arr[left] <= arr[left + 1]) left++;
            while (right - 1 >= left && arr[right] >= arr[right - 1]) right--;
            if (left >= right) return 0;

            int result = Math.Min(len - left - 1, right);
            if (left + 1 <= len - right)  // 左驱动右
            {
                for (int l = left, r; l >= 0 && right - l - 1 < result; l--)   // l是左边保留的边界
                {
                    r = BinarySearchRight(arr, right, len - 1, arr[l]);
                    result = Math.Min(result, r - l - 1);
                }
            }
            else                          // 右驱动左
            {
                for (int r = right, l; r < len && r - left - 1 < result; r++)  // r是左边保留的边界
                {
                    l = BinarySearchLeft(arr, 0, left, arr[r]);
                    result = Math.Min(result, r - l - 1);
                }
            }

            return result;
        }

        /// <summary>
        /// 找第一个大于等于的
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearchRight(int[] arr, int left, int right, int target)
        {
            int result = right + 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (arr[mid] >= target)
                {
                    result = mid; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }

        /// <summary>
        /// 找最后一个小于等于的
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearchLeft(int[] arr, int left, int right, int target)
        {
            int result = -1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (arr[mid] <= target)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
