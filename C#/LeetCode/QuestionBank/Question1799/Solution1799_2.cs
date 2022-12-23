using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1799
{
    public class Solution1799_2 : Interface1799
    {
        /// <summary>
        /// 暴力解
        /// 与Solution1799一样，但是对已经求得的GCD做了缓存，空间换时间
        /// 
        /// 也可以考虑先将数组种每一个数字分解质因数，这样方便两两求最大公约数，但是貌似分解质因数的时间复杂度本来就很高，这里就步考虑了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxScore(int[] nums)
        {
            int result = 0;
            Dictionary<(int, int), int> gcds = new Dictionary<(int, int), int>();
            dfs(nums, new int[nums.Length >> 1], gcds, ref result);

            return result;
        }

        private void dfs(int[] nums, int[] buffer, Dictionary<(int, int), int> gcds, ref int result)
        {
            int len = nums.Length;
            if (len > 2)
            {
                for (int i = 1; i < len; i++)
                {
                    int[] _buffer = buffer.ToArray();
                    if (!gcds.ContainsKey((nums[0], nums[i])))
                    {
                        int gcd = GetGCD(nums[0], nums[i]);
                        gcds.Add((nums[0], nums[i]), gcd);
                        gcds.TryAdd((nums[i], nums[0]), gcd);
                    }
                    _buffer[_buffer.Length - (len >> 1)] = gcds[(nums[0], nums[i])];
                    dfs(nums.Where((_i, id) => id != 0 && id != i).ToArray(), _buffer, gcds, ref result);
                }
            }
            else  // if(len == 2)
            {
                if (!gcds.ContainsKey((nums[0], nums[1])))
                {
                    int gcd = GetGCD(nums[0], nums[1]);
                    gcds.Add((nums[0], nums[1]), gcd);
                    gcds.TryAdd((nums[1], nums[0]), gcd);
                }
                buffer[buffer.Length - 1] = gcds[(nums[0], nums[1])];
                Array.Sort(buffer);
                int _result = 0;
                for (int i = 0; i < buffer.Length; i++)
                {
                    _result += buffer[i] * (i + 1);
                }
                if (_result > result) result = _result;
            }
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            if ((x & 1) == 0 && (y & 1) == 0)
                return GetGCD(x >> 1, y >> 1) << 1;
            else if ((x & 1) == 0 && (y & 1) == 1)
                return GetGCD(x >> 1, y);
            else if ((x & 1) == 1 && (y & 1) == 0)
                return GetGCD(x, y >> 1);
            else
            {
                if (x > y)
                    return GetGCD(x - y, y);
                else
                    return GetGCD(x, y - x);
            }
        }
    }
}
