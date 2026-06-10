using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3691
{
    public class Solution3691_err : Interface3691
    {
        /// <summary>
        /// 贪心(贡献法) + 稀疏表 + Hash
        /// 1. 按照数组中值将索引排序，例如
        ///     nums = [1,3,2], 索引数组排序为 [0,1,2] --> [0,2,1]
        ///     这样使用双指针可以贪心的从大到小找出(max-min)的区间
        /// 2. 第1轮，没有问题，第2轮时需要验证子数组的最大值及最小值是否真的是双指针枚举的值
        ///     使用稀疏表快速查询区间的最大值及最小值
        ///     使用Hash快速判断是否是重复获取
        ///     
        /// 双指针是错的，会漏掉一些可能性，参考测试用例06
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxTotalValue(int[] nums, int k)
        {
            int len = nums.Length;
            // 索引排序
            int[] order = new int[len];
            for (int i = 1; i < len; i++) order[i] = i;
            Array.Sort(order, (x, y) => nums[x] != nums[y] ? nums[x] - nums[y] : x - y);
            if (nums[order[0]] == nums[order[^1]]) return 0;
            // 稀疏表
            sparsetable st = new sparsetable(nums);
            // 哈希表
            HashSet<(int, int)> set = new HashSet<(int, int)>();

            long result = 0, cnt;
            int pl = 0, pr = len - 1, l, r, min, max, diff;
            l = Math.Min(order[pl], order[pr]); r = Math.Max(order[pl], order[pr]); diff = Math.Abs(nums[r] - nums[l]);
            if ((cnt = 1L * (l + 1) * (len - r)) >= k) return 1L * diff * k;

            result = 1L * diff * cnt;
            for (int i = 0; i <= l; i++) for (int j = r; j < len; j++) set.Add((i, j));

            while (set.Count < k)
            {
                if (nums[order[pr]] - nums[order[pl + 1]] >= nums[order[pr - 1]] - nums[order[pl]]) pl++; else pr--;
                l = Math.Min(order[pl], order[pr]); r = Math.Max(order[pl], order[pr]); diff = Math.Abs(nums[r] - nums[l]);
                (min, max) = st.MinMax(l, r);
                if (min != Math.Min(nums[l], nums[r]) || max != Math.Max(nums[l], nums[r])) continue;
                if ((diff = max - min) == 0) break;
                for (int i = l; i >= 0 && nums[i] >= min && nums[i] <= max; i--)
                {
                    for (int j = r; j < len && nums[j] >= min && nums[j] <= max; j++)
                    {
                        if (!set.Add((i, j))) break;
                        result += diff;
                        if (set.Count == k) goto END;
                    }
                }
            }
        END:;

            return result;
        }

        public class sparsetable
        {
            public sparsetable(int[] nums)
            {
                minst = [[.. nums]];
                maxst = [[.. nums]];
                length = nums.Length;
                int span = 2, half = 1;
                while (span <= length)
                {
                    minst.Add(new int[length - span + 1]);
                    maxst.Add(new int[length - span + 1]);
                    for (int i = 0, j = half, R = span - 1; R < length; i++, j++, R++)
                    {
                        minst[^1][i] = Math.Min(minst[^2][i], minst[^2][j]);
                        maxst[^1][i] = Math.Max(maxst[^2][i], maxst[^2][j]);
                    }
                    span <<= 1; half <<= 1;
                }
            }

            private List<int[]> minst, maxst;
            private int length;

            public (int, int) MinMax(int left, int right)
            {
                if (left < 0 || right >= length) throw new ArgumentOutOfRangeException();
                int idx = 0, span = 1;
                while ((span << 1) <= right - left + 1) { idx++; span <<= 1; }
                return (Math.Min(minst[idx][left], minst[idx][right - span + 1]), Math.Max(maxst[idx][left], maxst[idx][right - span + 1]));
            }
        }
    }
}
