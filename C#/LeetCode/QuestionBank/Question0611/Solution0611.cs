using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0611
{
    public class Solution0611 : Interface0611
    {
        /// <summary>
        /// 排序 + 二分
        /// 排序后，两层循环枚举两条小边，二分查找大边的边界
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TriangleNumber(int[] nums)
        {
            if (nums.Length < 3) return 0;

            Array.Sort(nums);
            int result = 0, start = 0, len = nums.Length;
            while (start < len && nums[start] == 0) start++;
            if (len - start < 2) return 0;
            for (int i = start, k; i < len; i++) for (int j = i + 1; j < len; j++)
                {
                    k = BinarySearch(j + 1, nums[i] + nums[j]);
                    result += k - j;
                }

            return result;

            int BinarySearch(int left, int target)
            {
                int _result = left - 1, right = len - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (nums[mid] < target) { _result = mid; left = mid + 1; } else { right = mid - 1; }
                }

                return _result;
            }
        }

        /// <summary>
        /// 逻辑同TriangleNumber()，二分的时候增加了剪枝
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TriangleNumber2(int[] nums)
        {
            if (nums.Length < 3) return 0;

            Array.Sort(nums);
            int result = 0, start = 0, len = nums.Length;
            while (start < len && nums[start] == 0) start++;
            if (len - start < 2) return 0;
            for (int i = start; i < len; i++) for (int j = i + 1, k = i + 2; j < len; j++)
                {
                    k = BinarySearch(k, nums[i] + nums[j]);
                    result += k - j;
                }

            return result;

            int BinarySearch(int left, int target)
            {
                int _result = left - 1, right = len - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (nums[mid] < target) { _result = mid; left = mid + 1; } else { right = mid - 1; }
                }

                return _result;
            }
        }

        /// <summary>
        /// 逻辑依然同TriangleNumber()，题目的数据范围不大，将二分退化为三指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TriangleNumber3(int[] nums)
        {
            if (nums.Length < 3) return 0;

            Array.Sort(nums);
            int result = 0, start = 0, len = nums.Length;
            while (start < len && nums[start] == 0) start++;
            if (len - start < 2) return 0;
            for (int i = start, sum; i < len; i++) for (int j = i + 1, k = i + 1; j < len; j++)
                {
                    sum = nums[i] + nums[j];
                    while (k + 1 < len && nums[k + 1] < sum) k++;
                    result += k - j;
                }

            return result;
        }
    }
}
