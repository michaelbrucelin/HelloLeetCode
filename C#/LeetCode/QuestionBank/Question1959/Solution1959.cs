using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1959
{
    public class Solution1959 : Interface1959
    {
        /// <summary>
        /// DFS + 记忆化搜索 + 稀疏表 + 前缀和
        /// 调整k次，相等于把数组分为k+1段，每一段的 浪费值 = max*len - sum
        ///     max可以通过稀疏表快速查询，sum可以通过前缀和快速查询
        /// k+1段怎样分配可以通过 DFS + 记忆化搜索 来计算
        /// 
        /// 逻辑没问题，提交了多次才过了1次，参考测试用例04 05
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinSpaceWastedKResizing(int[] nums, int k)
        {
            int len = nums.Length;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + nums[i];
            List<int[]> st = [[.. nums]];
            int span = 1, half;
            while ((span <<= 1) <= len)
            {
                st.Add(new int[len - span + 1]);
                half = span >> 1;
                for (int i = 0, j = half, x = span - 1; x < len; i++, j++, x++) st[^1][i] = Math.Max(st[^2][i], st[^2][j]);
            }

            Dictionary<(int, int, int), int> memory = new Dictionary<(int, int, int), int>();
            return dfs(0, len - 1, k + 1);

            int dfs(int left, int right, int times)
            {
                if (left == right) return 0;
                if (memory.ContainsKey((left, right, times))) return memory[(left, right, times)];

                int result;
                if (times == 1)
                {
                    result = getwaste(left, right);
                    memory.Add((left, right, times), result);
                    return result;
                }

                result = int.MaxValue;
                for (int i = left; i < right; i++) result = Math.Min(result, getwaste(left, i) + dfs(i + 1, right, times - 1));

                memory.Add((left, right, times), result);
                return result;
            }

            int getwaste(int left, int right)
            {
                if (left == right) return 0;
                int span = 1, idx = 0;
                while ((span << 1) <= right - left + 1) { span <<= 1; idx++; }
                return Math.Max(st[idx][left], st[idx][right - span + 1]) * (right - left + 1) - sums[right + 1] + sums[left];
            }
        }
    }
}
