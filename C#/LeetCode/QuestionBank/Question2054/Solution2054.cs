using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2054
{
    public class Solution2054 : Interface2054
    {
        /// <summary>
        /// 排序 + 二分 + 前缀最大值
        /// 1. 将events数组按starttime升序排序
        /// 2. 预处理排序后数组的后缀最大值
        /// 3. 枚举events数组，二分查找出不相交的后缀区间，取后缀区间的最大值即可
        /// 
        /// 后缀最大值也可以用稀疏表来实现，这里场景就是后缀区间，所以直接使用后缀最大值
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public int MaxTwoEvents(int[][] events)
        {
            int result = events[0][2], len = events.Length;
            for (int i = 1; i < len; i++) result = Math.Max(result, events[i][2]);

            // Array.Sort(events, (x, y) => x[0] != y[0] ? x[0] - y[0] : x[1] - y[1]);
            Array.Sort(events, (x, y) => x[0] - y[0]);
            int[] suffix = new int[len]; suffix[len - 1] = events[len - 1][2];
            for (int i = len - 2; i > 0; i--) suffix[i] = Math.Max(events[i][2], suffix[i + 1]);

            for (int i = 0,j; i < len; i++)
            {
                j = BinarySearch(i + 1, events[i][1]);
                if(j<len) result=Math.Max(result, events[i][2] + suffix[j]);
            }

            return result;

            int BinarySearch(int left, int target)
            {
                int result = events.Length, right = events.Length - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (events[mid][0] > target)
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
        }
    }
}
