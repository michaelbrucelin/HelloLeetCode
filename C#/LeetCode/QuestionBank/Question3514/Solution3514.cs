using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3514
{
    public class Solution3514 : Interface3514
    {
        /// <summary>
        /// Hash + 枚举
        /// 1. nums[i] <= 1500，所以 nums[i]^nums[i] 与 nums[i]^nums[i]^nums[i] 都不会超过2047
        /// 2. 枚举全部的 nums[i]^nums[i] 将结果保存在 Hash 表中
        /// 3. 枚举 0 - 2047 中每个值，假定为 x，再枚举每个 nums[i]，看 Hash 表中是否包含 x^nums[i] 即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int UniqueXorTriplets(int[] nums)
        {
            HashSet<int> set = [];
            int max = 0, maxbits;
            foreach (int num in nums) { set.Add(num); max = Math.Max(max, num); }
            bool[] mask = new bool[(maxbits = findmax(max)) + 1];
            foreach (int x in set) foreach (int y in set) mask[x ^ y] = true;

            int result = 0;
            for (int i = 0; i <= maxbits; i++)
            {
                foreach (int x in set) if (mask[i ^ x]) { result++; break; }
            }

            return result;

            static int findmax(int x)
            {
                x |= x >> 1;
                x |= x >> 2;
                x |= x >> 4;
                x |= x >> 8;
                x |= x >> 16;
                return (x << 1) | 1;
            }
        }

        /// <summary>
        /// 逻辑同UniqueXorTriplets()，数据量较小，不使用Hash去重复了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int UniqueXorTriplets2(int[] nums)
        {
            int max = 0, maxbits;
            foreach (int num in nums) max = Math.Max(max, num);
            bool[] mask = new bool[(maxbits = findmax(max)) + 1];
            foreach (int x in nums) foreach (int y in nums) mask[x ^ y] = true;

            int result = 0;
            for (int i = 0; i <= maxbits; i++)
            {
                foreach (int x in nums) if (mask[i ^ x]) { result++; break; }
            }

            return result;

            static int findmax(int x)
            {
                x |= x >> 1;
                x |= x >> 2;
                x |= x >> 4;
                x |= x >> 8;
                x |= x >> 16;
                return (x << 1) | 1;
            }
        }
    }
}
