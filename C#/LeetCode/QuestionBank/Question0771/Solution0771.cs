using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0771
{
    public class Solution0771 : Interface0771
    {
        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="jewels"></param>
        /// <param name="stones"></param>
        /// <returns></returns>
        public int NumJewelsInStones(string jewels, string stones)
        {
            HashSet<char> set = new HashSet<char>(jewels);
            int result = 0;
            for (int i = 0; i < stones.Length; i++)
            {
                if (set.Contains(stones[i])) result++;
            }

            return result;
        }

        /// <summary>
        /// 数组
        /// </summary>
        /// <param name="jewels"></param>
        /// <param name="stones"></param>
        /// <returns></returns>
        public int NumJewelsInStones2(string jewels, string stones)
        {
            int[] set = new int[58];
            for (int i = 0; i < jewels.Length; i++) set[jewels[i] - 'A']++;
            int result = 0;
            for (int i = 0; i < stones.Length; i++)
            {
                if (set[stones[i] - 'A'] > 0) result++;
            }

            return result;
        }

        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="jewels"></param>
        /// <param name="stones"></param>
        /// <returns></returns>
        public int NumJewelsInStones3(string jewels, string stones)
        {
            long set = 0L;
            for (int i = 0; i < jewels.Length; i++) set |= 1L << (jewels[i] - 'A');
            int result = 0;
            for (int i = 0; i < stones.Length; i++)
            {
                if ((set & (1L << (stones[i] - 'A'))) != 0) result++;
            }

            return result;
        }
    }
}
