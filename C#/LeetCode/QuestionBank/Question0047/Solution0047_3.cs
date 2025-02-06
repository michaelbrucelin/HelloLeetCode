using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0047
{
    public class Solution0047_3 : Interface0047
    {
        /// <summary>
        /// 字典序
        /// 字典序即找到比当前大的最小值，例如45122字典序的下一个值是45221
        /// 1. 左边小的数值与右边大的数值交换位置，才会变大
        /// 2. 交换的位置越靠右越好
        /// 3. 如果一个区间倒序排列，那这个区间已经达到最大值
        /// 基于上面3点，可以这样找出字典序的下一个值
        /// 1. 从右向左找出第一组相邻的id，i,j=i+1，使nums[i] < nums[j]
        ///     nums[j..]倒序，这个区间已经使最大值
        /// 2. 在nums[j..]中二分找出大于nums[i]的最小值，假定使nums[k]
        /// 3. 交换nums[i]与nums[k]
        /// 4. 使nums[j..]反转
        ///     nums[j..]倒序，反转即正序，即最小值
        /// 5. 当nums[0..]全部倒序，循环即停止，即到达整个序列的最大值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            result.Add(nums.ToArray());
            int i, j, len = nums.Length;
            while (true)
            {
                for (i = len - 2; i >= 0 && nums[i] >= nums[i + 1]; i--) ;
                if (i == -1) break;
                j = BinarySearch(i + 1, len - 1, nums[i]);
                nums[i] ^= nums[j]; nums[j] ^= nums[i]; nums[i] ^= nums[j];
                for (i = i + 1, j = len - 1; i < j; i++, j--)
                {
                    nums[i] ^= nums[j]; nums[j] ^= nums[i]; nums[i] ^= nums[j];
                }
                result.Add(nums.ToArray());
            }

            return result;

            int BinarySearch(int left, int right, int target)
            {
                int result = left, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (nums[mid] > target)
                    {
                        result = mid;
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// 逻辑同PermuteUnique()，部分代码使用.net api
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique2(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            result.Add(nums.ToArray());
            int i, j, len = nums.Length;
            while (true)
            {
                for (i = len - 2; i >= 0 && nums[i] >= nums[i + 1]; i--) ;
                if (i == -1) break;
                j = BinarySearch(i + 1, len - 1, nums[i]);
                nums[i] ^= nums[j]; nums[j] ^= nums[i]; nums[i] ^= nums[j];
                Array.Reverse(nums, i + 1, len - i - 1);
                result.Add(nums.ToArray());
            }

            return result;

            // Array.BinarySearch()不知道怎么用
            int BinarySearch(int left, int right, int target)
            {
                int result = left, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (nums[mid] > target)
                    {
                        result = mid;
                        left = mid + 1;
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
}
