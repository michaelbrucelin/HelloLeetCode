using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1665
{
    public class Solution1665_err : Interface1665
    {
        /// <summary>
        /// 二分
        /// 先按照tasks[i][1]降序排序，然后二分查找结果
        /// 如要想要极致，怎样定位二分的上界，是否有数学解？
        /// 
        /// 逻辑错误，参考测试用例02
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public int MinimumEffort(int[][] tasks)
        {
            Array.Sort(tasks, (x, y) => y[1] - x[1]);
            int sum = 0, max = 0, len = tasks.Length;
            for (int i = 0; i < len; i++)
            {
                sum += tasks[i][0]; max = Math.Max(max, tasks[i][1]);
            }

            int result = sum + max, low = sum, high = sum + max, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (check(mid))
                {
                    result = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;

            bool check(int x)
            {
                for (int i = 0; i < len; i++)
                {
                    if (x < tasks[i][1]) return false;
                    x -= tasks[i][0];
                }
                return true;
            }
        }
    }
}
