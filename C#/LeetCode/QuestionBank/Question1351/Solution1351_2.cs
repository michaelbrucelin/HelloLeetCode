using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1351
{
    public class Solution1351_2 : Interface1351
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CountNegatives(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            for (int r = 0, c = ccnt; r < rcnt; r++)
            {
                int left = 0, right = ccnt - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (grid[r][mid] < 0)
                    {
                        c = mid; right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                result += ccnt - c;
            }

            return result;
        }
    }
}
