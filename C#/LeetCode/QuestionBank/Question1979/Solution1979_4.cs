using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1979
{
    public class Solution1979_4
    {
        /// <summary>
        /// 辗转相除法 + 更相减损术
        /// 结合使用辗转相除法与更相减损术的优势，在更相减损术基础上通过移位运算来加速
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindGCD(int[] nums)
        {
            int min = nums[0], max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < min) min = nums[i]; else if (nums[i] > max) max = nums[i];
            }

            return GetGCD(min, max);

            static int GetGCD(int x, int y)
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

        public int FindGCD2(int[] nums)
        {
            int min = nums[0], max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < min) min = nums[i]; else if (nums[i] > max) max = nums[i];
            }

            return GetGCD(min, max);

            static int GetGCD(int x, int y)
            {
                if (x == y) return x;

                int move = 0;
                while (x != y)
                {
                    switch ((x & 1, y & 1))
                    {
                        case (0, 0): x >>= 1; y >>= 1; move++; break;
                        case (0, 1): x >>= 1; break;
                        case (1, 0): y >>= 1; break;
                        default:  // (1, 1)
                            if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                            break;
                    }
                }

                return x << move;
            }
        }
    }
}
