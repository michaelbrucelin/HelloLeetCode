using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4010
{
    public class Solution4010 : Interface4010
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxPairStrength(int[] nums)
        {
            long result = 0, len = nums.Length;
            for (int i = 0, _gcd; i < len; i++) for (int j = i + 1; j < len; j++)
                {
                    _gcd = gcd(nums[i], nums[j]);
                    result = Math.Max(result, 1L * nums[i] * nums[j] / _gcd / _gcd);
                }

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
        /// 逻辑完全同MaxPairStrength()，添加剪枝优化
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxPairStrength2(int[] nums)
        {
            long result = 0, prod; int _gcd, len = nums.Length;
            Array.Sort(nums);
            for (int i = len - 1; i >= 0; i--) for (int j = i - 1; j >= 0; j--)
                {
                    if ((prod = 1L * nums[i] * nums[j]) <= result) break;
                    _gcd = gcd(nums[i], nums[j]);
                    result = Math.Max(result, prod / _gcd / _gcd);
                }

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
        /// 逻辑完全同MaxPairStrength2()，继续剪枝
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxPairStrength3(int[] nums)
        {
            long result = 0, prod, allgcd; int _gcd, _allgcd, len = nums.Length;
            Array.Sort(nums);
            _allgcd = gcd(nums[0], nums[1]);
            for (int i = 2; i < len && _allgcd > 1; i++) _allgcd = gcd(_allgcd, nums[i]);
            allgcd = 1L * _allgcd * _allgcd;
            for (int i = len - 1; i >= 0; i--) for (int j = i - 1; j >= 0; j--)
                {
                    if ((prod = 1L * nums[i] * nums[j]) / allgcd <= result) break;
                    _gcd = gcd(nums[i], nums[j]);
                    result = Math.Max(result, prod / _gcd / _gcd);
                }

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
    }
}
