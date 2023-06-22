using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1385
{
    public class Solution1385_2 : Interface1385
    {
        /// <summary>
        /// 二分法
        /// 对于num，只要arr2中不含有[num-d, num+d]区间的值即可
        /// 1. 排序arr2，找出最小值min与最大值max
        /// 2. 如果max < num-d 或 min > num+d，符合
        /// 3. 二分法找出arr2中第一个大于等于num-d的值num，如果num小于等于num+d，不符合，否则，符合
        /// 
        /// arr1排序也有一点优化，但是不好评估有没有实际意义，这里就不写了
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            Array.Sort(arr2);

            int result = 0, L, R, min = arr2[0], max = arr2[^1];
            for (int i = 0; i < arr1.Length; i++)
            {
                L = arr1[i] - d; R = arr1[i] + d;
                if (L > max || R < min)
                {
                    result++;
                }
                else
                {
                    int id = BinarySearch(arr2, L);
                    if (arr2[id] > R) result++;  // 这里的id一定不会数组越界，不需要判断越界
                }
            }

            return result;
        }

        private int BinarySearch(int[] arr, int target)
        {
            int result = arr.Length, low = 0, high = arr.Length - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (arr[mid] >= target)
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
