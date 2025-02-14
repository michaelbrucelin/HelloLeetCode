using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1552
{
    public class Solution1552 : Interface1552
    {
        /// <summary>
        /// 排序 + 二分
        /// </summary>
        /// <param name="position"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int MaxDistance(int[] position, int m)
        {
            Array.Sort(position);
            int result = -1, n = position.Length, min = position[0], max = position[^1];
            int low = 1, high = (max - min) / (m - 1), mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (check(mid))
                {
                    result = mid; low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return result;

            bool check(int x)
            {
                int last = 0, next, _m = m - 1;
                while (_m > 0)
                {
                    next = last + 1;
                    while (next < n && position[next] - position[last] < x) next++;
                    if (next == n) return false;
                    last = next;
                    _m--;
                }

                return true;
            }
        }
    }
}
