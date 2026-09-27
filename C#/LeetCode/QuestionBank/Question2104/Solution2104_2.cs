using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2104
{
    public class Solution2104_2 : Interface2104
    {
        /// <summary>
        /// 稀疏表
        /// 
        /// 与Solution2104相比，没有任何提高，只是单纯想写一下稀疏表而已
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long SubArrayRanges(int[] nums)
        {
            long result = 0;
            SparseTable maxst = new SparseTable(nums);
            for (int i = 0, len = nums.Length; i < len; i++) for (int j = i; j < len; j++) result += maxst.Diff(i, j);

            return result;
        }

        public class SparseTable
        {
            public SparseTable(int[] nums)
            {
                this.nums = nums;
                Built();
                int len = nums.Length;
                logs = new int[len + 1];
                for (int i = 2; i <= len; i++) logs[i] = logs[i >> 1] + 1;
            }

            private int[] nums, logs;
            private List<int[]> mins, maxs;

            private void Built()
            {
                int len = nums.Length;
                mins = [nums]; maxs = [nums];
                int span = 2, _span = 1, _len;
                while (span <= len)
                {
                    int[] _min = new int[_len = len - span + 1];
                    int[] _max = new int[_len = len - span + 1];
                    for (int i = 0, j = span - _span; i < _len; i++, j++)
                    {
                        _min[i] = Math.Min(mins[^1][i], mins[^1][j]);
                        _max[i] = Math.Max(maxs[^1][i], maxs[^1][j]);
                    }
                    mins.Add(_min); maxs.Add(_max);
                    span <<= 1; _span <<= 1;
                }
            }

            public int Diff(int left, int right)
            {
                int idx = logs[right - left + 1], span = 1 << idx;
                return Math.Max(maxs[idx][left], maxs[idx][right - span + 1]) - Math.Min(mins[idx][left], mins[idx][right - span + 1]);
            }
        }
    }
}
