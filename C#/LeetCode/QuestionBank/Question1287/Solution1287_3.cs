using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1287
{
    public class Solution1287_3
    {
        /// <summary>
        /// 随机化 + 二分法
        /// 随机化取数组中的一个值，二分法统计数组中有多少个这个值，没有生产意义，只是写着玩的
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindSpecialInteger(int[] arr)
        {
            int len = arr.Length, p25 = arr.Length >> 2, id;
            Random random = new Random();
            id = random.Next(0, len);
            while (true)
            {
                if (CountValue(arr, id) > p25) return arr[id];
                id = random.Next(0, len);
            }
        }

        private int CountValue(int[] arr, int targetid)
        {
            int left = targetid, right = targetid, target = arr[targetid];
            int low = 0, high = targetid, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (arr[mid] == target)
                {
                    left = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            low = targetid; high = arr.Length - 1;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (arr[mid] == target)
                {
                    right = mid; low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return right - left + 1;
        }
    }
}
