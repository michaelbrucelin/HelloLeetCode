using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0278
{
    public class Solution0278 : VersionControl, Interface0278
    {
        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int low = 0, high = n, mid, result = -1;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (IsBadVersion(mid))
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
