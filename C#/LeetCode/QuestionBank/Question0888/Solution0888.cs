using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0888
{
    public class Solution0888 : Interface0888
    {
        /// <summary>
        /// 数学
        /// 如果alice比bob多x，那么交换时alice比bob少x/2即可
        /// </summary>
        /// <param name="aliceSizes"></param>
        /// <param name="bobSizes"></param>
        /// <returns></returns>
        public int[] FairCandySwap(int[] aliceSizes, int[] bobSizes)
        {
            int diff = (aliceSizes.Sum() - bobSizes.Sum()) >> 1;

            HashSet<int> alice = new HashSet<int>(aliceSizes);

            for (int i = 0; i < bobSizes.Length; i++)
                if (alice.Contains(bobSizes[i] + diff)) return new int[] { bobSizes[i] + diff, bobSizes[i] };

            throw new Exception("logic error");
        }
    }
}
