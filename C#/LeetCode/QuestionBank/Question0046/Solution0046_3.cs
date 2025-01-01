using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode.QuestionBank.Question0046
{
    public class Solution0046_3 : Interface0046
    {
        /// <summary>
        /// 字典序
        /// 1. 将数组升序排序
        /// 2. 从右向左找到第一个相邻的升序对 (i, i+1)，使得 array[i] < array[i+1]。如果不存在这样的升序对，则说明当前排列是最后一个排列
        /// 3. 在 i 右侧找到比 array[i] 大的最小元素 array[j]（即满足 array[j] > array[i] 的最大 j）
        /// 4. 交换 array[i] 和 array[j]
        /// 5. 将 i 右侧的元素反转（因为交换后右侧已按降序排列）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            int cnt = nums.Length;
            result.Add(nums.ToArray());
            while (true)
            {
                for (int i = cnt - 2, j; i >= 0; i--) if (nums[i] < nums[i + 1])
                    {
                        j = binary_search(i + 1, cnt - 1, nums[i]);
                        swap(i, j);
                        reverse(i + 1, cnt - 1);
                        result.Add(nums.ToArray());
                        goto CONTINUE;
                    }
                break;
            CONTINUE:;
            }

            return result;

            int binary_search(int left, int right, int target)
            {
                int result = left, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (nums[mid] > target)
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

            void reverse(int left, int right)
            {
                while (left < right)
                {
                    swap(left, right);
                    left++;
                    right--;
                }
            }

            void swap(int i, int j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
    }
}
