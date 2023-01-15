using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1819
{
    public class Solution1819 : Interface1819
    {
        /// <summary>
        /// dfs
        /// 如果一个子序列的最大公约数是x，那么这个序列新增一个元素k后，新的序列的最大公约数就是GCD(x, k)
        /// 用一个字典记录已经计算过的两个数的公约数
        /// 
        /// 测试计算结果没有错误，但是提交会超时，参考测试用例5
        /// 这里dfs遍历了所有可能的子序列，所以如果数组中有n个元素，那么就有pow(2,n)个子序列，根据题目的数量级，超时很正常
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountDifferentSubsequenceGCDs(int[] nums)
        {
            nums = new HashSet<int>(nums).ToArray();  // 去重复，不影响结果
            if (nums.Length == 1) return 1;

            HashSet<int> gcds = new HashSet<int>(nums);
            Dictionary<(int, int), int> buffer = new Dictionary<(int, int), int>();
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != 1) dfs(nums, nums[i], i + 1, buffer, gcds);

            return gcds.Count;
        }

        private void dfs(int[] nums, int gcd, int start, Dictionary<(int, int), int> buffer, HashSet<int> gcds)
        {
            for (int i = start; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    gcds.Add(1); continue;
                }
                else if (nums[i] == gcd)
                {
                    dfs(nums, gcd, i + 1, buffer, gcds);
                }
                else
                {
                    int x = Math.Min(gcd, nums[i]), y = Math.Max(gcd, nums[i]);
                    if (!buffer.ContainsKey((x, y))) buffer.Add((x, y), GetGCD(x, y));
                    int _gcd = buffer[(x, y)];
                    gcds.Add(_gcd);
                    if (_gcd != 1) dfs(nums, _gcd, i + 1, buffer, gcds);
                }
            }
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            int move = 0;
            while (x != y)
            {
                if ((x & 1) == 0 && (y & 1) == 0)
                {
                    x >>= 1; y >>= 1; move++;
                }
                else if ((x & 1) == 0 && (y & 1) == 1) x >>= 1;
                else if ((x & 1) == 1 && (y & 1) == 0) y >>= 1;
                else
                {
                    if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                }
            }

            return x << move;
        }
    }
}
