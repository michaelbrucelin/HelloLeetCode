using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3202
{
    public class Solution3202 : Interface3202
    {
        /// <summary>
        /// 暴力枚举
        /// 三层循环
        ///     1. 遍历每种余数的组合 x, y
        ///     2. 计算这种组合的最大子序列长度
        /// 按照题目的限定，时间复杂度会来到10^9，先写出来，大概率会TLE
        /// 
        /// ... 提交通过了
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumLength2(int[] nums, int k)
        {
            if (nums.Length < 3) return nums.Length;

            int result = 0, len = nums.Length;
            List<int>[] dist = new List<int>[k];
            for (int i = 0; i < k; i++) dist[i] = [];
            for (int i = 0; i < len; i++) dist[nums[i] % k].Add(i);
            for (int x = 0; x < k; x++) for (int y = 0; y <= x; y++) result = Math.Max(result, calen(x, y));  // x, y是子序列相邻两项的余数

            return result;

            int calen(int x, int y)
            {
                if (x == y) return dist[x].Count;
                if (dist[x].Count < 2 && dist[y].Count < 2) return dist[x].Count + dist[y].Count;

                int cnt = 2, cntx = dist[x].Count, cnty = dist[y].Count, px = 0, py = 0;
                while (px < cntx && py < cnty)
                {
                    if (dist[x][px] < dist[y][py])
                    {
                        while (++px < cntx && dist[x][px] < dist[y][py]) ;
                        if (px < cntx) cnt++;
                    }
                    else
                    {
                        while (++py < cnty && dist[y][py] < dist[x][px]) ;
                        if (py < cnty) cnt++;
                    }
                }

                return cnt;
            }
        }

        /// <summary>
        /// 逻辑完全同MaximumLength()，将calen()中的双指针改为二分查找试试
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumLength(int[] nums, int k)
        {
            if (nums.Length < 3) return nums.Length;

            int result = 0, len = nums.Length;
            List<int>[] dist = new List<int>[k];
            for (int i = 0; i < k; i++) dist[i] = [];
            for (int i = 0; i < len; i++) dist[nums[i] % k].Add(i);
            for (int x = 0; x < k; x++) for (int y = 0; y <= x; y++) result = Math.Max(result, calen(x, y));  // x, y是子序列相邻两项的余数

            return result;

            int calen(int x, int y)
            {
                if (x == y) return dist[x].Count;
                if (dist[x].Count < 2 && dist[y].Count < 2) return dist[x].Count + dist[y].Count;

                int cnt = 2, cntx = dist[x].Count, cnty = dist[y].Count, px = 0, py = 0;
                while (px < cntx && py < cnty)
                {
                    if (dist[x][px] < dist[y][py])
                    {
                        // while (++px < cntx && dist[x][px] < dist[y][py]) ;
                        px = binarysearch(x, px + 1, dist[y][py]);
                        if (px < cntx) cnt++;
                    }
                    else
                    {
                        // while (++py < cnty && dist[y][py] < dist[x][px]) ;
                        py = binarysearch(y, py + 1, dist[x][px]);
                        if (py < cnty) cnt++;
                    }
                }

                return cnt;
            }

            int binarysearch(int id, int start, int target)
            {
                int find = dist[id].Count;
                int left = start, right = find - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (dist[id][mid] > target)
                    {
                        find = mid; right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                return find;
            }
        }
    }
}
