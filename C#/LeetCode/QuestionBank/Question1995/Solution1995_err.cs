using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1995
{
    public class Solution1995_err : Interface1995
    {
        /// <summary>
        /// 排序 + 二分查找
        /// 1. 去重复（计数）排序
        /// 2. 前三个元素排列组合，第4个元素二分查找
        /// 
        /// 这样是错误的，这样做相当于相等的元素不允许重复使用了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountQuadruplets(int[] nums)
        {
            Array.Sort(nums);
            List<int> _nums = new List<int>() { nums[0] }, _cnts = new List<int> { 1 };
            int id = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == _nums[id])
                {
                    _cnts[id]++;
                }
                else
                {
                    _nums.Add(nums[i]); _cnts.Add(1); id++;
                }
            }

            int result = 0, _sum, sum, len = _nums.Count;
            id = 3;
            for (int a = 0; a < len; a++) for (int b = a + 1; b < len; b++)
                {
                    _sum = _nums[a] + _nums[b];
                    for (int c = b + 1; c < len; c++)
                    {
                        sum = _sum + _nums[c];
                        id = BinarySearch(_nums, id, sum);
                        if (id == len) goto End;
                        if (_nums[id] == sum)
                            result = _cnts[a] * _cnts[b] * _cnts[c] * _cnts[id];
                    }
                }
            End:
            return result;
        }

        /// <summary>
        /// 找出大于等于目标的最小坐标
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearch(List<int> nums, int start, int target)
        {
            int result = nums.Count, low = start, high = nums.Count - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (nums[mid] >= target)
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
