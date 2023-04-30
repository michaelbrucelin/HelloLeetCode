using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1287
{
    public class Solution1287_off_2 : Interface1287
    {
        public int FindSpecialInteger(int[] arr)
        {
            int span = arr.Length / 4 + 1;
            for (int i = 0; i < arr.Length; i += span)
                if (CountValue(arr, i) >= span) return arr[i];

            throw new Exception("TestCase Or Code Logic Error.");  // 题目保证了一定有唯一解
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
