using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3867
{
    public class Solution3867 : Interface3867
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long GcdSum(int[] nums)
        {
            int max = nums[0], len = nums.Length;
            int[] gcds = new int[len];
            gcds[0] = nums[0];
            for (int i = 1; i < len; i++) gcds[i] = gcd(nums[i], max = Math.Max(max, nums[i]));

            long result = 0;
            Array.Sort(gcds);
            for (int i = 0, j = len - 1; i < j; i++, j--) result += gcd(gcds[i], gcds[j]);

            return result;

            static int gcd(int x, int y)
            {
                if (x == y) return x;

                int move = 0;
                while (x != y) switch ((x & 1, y & 1))
                    {
                        case (0, 0): x >>= 1; y >>= 1; move++; break;
                        case (0, 1): x >>= 1; break;
                        case (1, 0): y >>= 1; break;
                        default:  // (1, 1)
                            if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                            break;
                    }

                return x << move;
            }
        }

        /// <summary>
        /// 逻辑同GcdSum()，添加一层记忆化试试
        /// 
        /// 弄巧成拙了，哈希化的成本大于计算gcd的成本了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long GcdSum2(int[] nums)
        {
            int max = nums[0], len = nums.Length;
            int[] gcds = new int[len];
            gcds[0] = nums[0];
            Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();
            for (int i = 1; i < len; i++) gcds[i] = gcd(nums[i], max = Math.Max(max, nums[i]));

            long result = 0;
            Array.Sort(gcds);
            for (int i = 0, j = len - 1; i < j; i++, j--) result += gcd(gcds[i], gcds[j]);

            return result;

            int gcd(int x, int y)
            {
                if (x == y) return x;
                if (x > y) (x, y) = (y, x);
                if (memory.ContainsKey((x, y))) return memory[(x, y)];

                int move = 0, kx = x, ky = y;
                while (x != y) switch ((x & 1, y & 1))
                    {
                        case (0, 0): x >>= 1; y >>= 1; move++; break;
                        case (0, 1): x >>= 1; break;
                        case (1, 0): y >>= 1; break;
                        default:  // (1, 1)
                            if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                            break;
                    }
                x <<= move;

                memory.Add((kx, ky), x);
                return x;
            }
        }
    }
}
