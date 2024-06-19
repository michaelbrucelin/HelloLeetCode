using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2713
{
    public class Solution2713_3 : Interface2713
    {
        /// <summary>
        /// 排序 + 贪心
        /// 1. 将mat展平，并按照值由大到小排序，除了值之外，需要保留值在mat中的rid与cid（可以使用优先级队列来代替战平数组并排序）
        /// 2. 从前向后遍历展平后的数据，当遍历到(val, r, c)时，需要
        ///     找出 r 行中已有结果中 _val > val 的最大结果
        ///     找出 c 列中已有结果中 _val > val 的最大结果
        ///     为了加速这个查找过程，可以使用 List<(int val, int max_r)> 来记录某一行/列的结果
        ///     max_r 表示这一行/列所有 _val >= val 的最大结果是 max_r
        ///     由于遍历的过程，val 单调不增，所以 List<(int val, int max_r)> 新增一项时，max_r 就是自身与 List 中最后一项的 max_r 的最大值，O(1)
        ///     这样就可以使用二分来快速查找了
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int MaxIncreasingCells(int[][] mat)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            List<(int val, int max_r)>[] rrs = new List<(int val, int max_r)>[rcnt];
            for (int r = 0; r < rcnt; r++) rrs[r] = new List<(int val, int max_r)>() { ((int)1e5 + 1, 0) };
            List<(int val, int max_r)>[] crs = new List<(int val, int max_r)>[ccnt];
            for (int c = 0; c < ccnt; c++) crs[c] = new List<(int val, int max_r)>() { ((int)1e5 + 1, 0) };

            PriorityQueue<(int val, int r, int c), int> maxpq = new PriorityQueue<(int val, int r, int c), int>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) maxpq.Enqueue((mat[r][c], r, c), -mat[r][c]);
            int result = 1, _result, _val; int _r; int _c;
            while (maxpq.Count > 0)
            {
                (_val, _r, _c) = maxpq.Dequeue();
                _result = Math.Max(BinarySearch(rrs[_r], _val), BinarySearch(crs[_c], _val)) + 1;
                result = Math.Max(result, _result);
                rrs[_r].Add((_val, Math.Max(_result, rrs[_r][^1].max_r)));
                crs[_c].Add((_val, Math.Max(_result, crs[_c][^1].max_r)));
            }

            return result;
        }

        private int BinarySearch(List<(int val, int max_r)> list, int target)
        {
            int result = 0, left = 0, right = list.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid].val > target)
                {
                    result = list[mid].max_r; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
