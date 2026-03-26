using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3548
{
    public class Solution3548 : Interface3548
    {
        /// <summary>
        /// 预处理 + Hash + 二分查找
        /// 1. 预处理出来grid每一行，每一列的和
        /// 2. 逐行逐列判断，如果两部分不等，计算两部分的差，看看大的那部分中是否含有“差”
        ///     判断大的那部分是否含有“差”，不能用区域Hash，那样Hash就太大了，可以记录grid中值的位置
        /// 
        /// 思路不难，情况比较多
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool CanPartitionGrid(int[][] grid)
        {
            long sum = 0; int rcnt = grid.Length, ccnt = grid[0].Length;
            long[] rsum = new long[rcnt], csum = new long[ccnt];
            Dictionary<long, (List<int>, List<int>)> map = new Dictionary<long, (List<int>, List<int>)>();
            for (int r = 0, num; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    num = grid[r][c];
                    sum += num; rsum[r] += num; csum[c] += num;
                    if (map.TryGetValue(num, out var t)) { t.Item1.Add(r); t.Item2.Add(c); } else { map.Add(num, ([r], [c])); }
                }

            long _sum = 0, diff;
            for (int r = 1; r < rcnt; r++)
            {
                _sum += rsum[r - 1];
                if ((diff = _sum - (sum - _sum)) == 0) return true;
                if (diff > 0)
                {
                    if (map.TryGetValue(diff, out var t))
                    {
                        if (r == 1)
                        {
                            if (grid[0][0] == diff || grid[0][ccnt - 1] == diff) return true;
                        }
                        else if (ccnt == 1)
                        {
                            if (grid[0][0] == diff || grid[r - 1][0] == diff) return true;
                        }
                        else  // if (r > 1 && ccnt > 1)
                        {
                            if (binary_search(t.Item1, 0, r - 1)) return true;
                        }
                    }
                }
                else
                {
                    diff = -diff;
                    if (map.TryGetValue(diff, out var t))
                    {
                        if (r == rcnt - 1)
                        {
                            if (grid[r][0] == diff || grid[r][ccnt - 1] == diff) return true;
                        }
                        else if (ccnt == 1)
                        {
                            if (grid[r][0] == diff || grid[rcnt - 1][0] == diff) return true;
                        }
                        else  // if (r < rcnt - 1 && ccnt > 1)
                        {
                            if (binary_search(t.Item1, r, rcnt - 1)) return true;
                        }
                    }
                }
            }

            _sum = 0;
            for (int c = 1; c < ccnt; c++)
            {
                _sum += csum[c - 1];
                if ((diff = _sum - (sum - _sum)) == 0) return true;
                if (diff > 0)
                {
                    if (map.TryGetValue(diff, out var t))
                    {
                        if (c == 1)
                        {
                            if (grid[0][0] == diff || grid[rcnt - 1][0] == diff) return true;
                        }
                        else if (rcnt == 1)
                        {
                            if (grid[0][0] == diff || grid[0][c - 1] == diff) return true;
                        }
                        else  // if (c > 1 && rcnt > 1)
                        {
                            if (binary_search(t.Item2, 0, c - 1)) return true;
                        }
                    }
                }
                else
                {
                    diff = -diff;
                    if (map.TryGetValue(diff, out var t))
                    {
                        if (c == ccnt - 1)
                        {
                            if (grid[0][c] == diff || grid[rcnt - 1][c] == diff) return true;
                        }
                        if (rcnt == 1)
                        {
                            if (grid[0][c] == diff || grid[0][ccnt - 1] == diff) return true;
                        }
                        else  // if (c < ccnt - 1 && rcnt > 1)
                        {
                            if (binary_search(t.Item2, c, ccnt - 1)) return true;
                        }
                    }
                }
            }

            return false;

            bool binary_search(List<int> list, int low, int high)
            {
                int left = 0, right = list.Count - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (low <= list[mid] && list[mid] <= high) return true;
                    if (list[mid] < low) left = mid + 1; else right = mid - 1;
                }

                return false;
            }
        }
    }
}
