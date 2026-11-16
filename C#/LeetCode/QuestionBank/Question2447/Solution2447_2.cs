using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2447
{
    public class Solution2447_2 : Interface2447
    {
        /// <summary>
        /// LogTrick
        /// 
        /// 没写完，先不写了
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarrayGCD(int[] nums, int k)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                if (nums[i] == k) result++;
                for (int j = i - 1; j >= 0 && GetGCD(nums[j], nums[i]) != nums[j]; j--)
                {
                    if ((nums[j] = GetGCD(nums[j], nums[i])) == k) result++;
                }
            }

            return result;

            static int GetGCD(int x, int y)
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
