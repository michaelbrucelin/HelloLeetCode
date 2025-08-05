using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3477
{
    public class Solution3477 : Interface3477
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="fruits"></param>
        /// <param name="baskets"></param>
        /// <returns></returns>
        public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
        {
            int len = fruits.Length;
            bool[] mask = new bool[len];
            for (int i = 0, fruit; i < len; i++)
            {
                fruit = fruits[i];
                for (int j = 0; j < len; j++) if (!mask[j] && baskets[j] >= fruit)
                    {
                        mask[j] = true;
                        break;
                    }
            }

            int result = 0;
            for (int i = 0; i < len; i++) if (!mask[i]) result++;
            return result;
        }

        /// <summary>
        /// 逻辑同NumOfUnplacedFruits()，将bool[]改成整型
        /// </summary>
        /// <param name="fruits"></param>
        /// <param name="baskets"></param>
        /// <returns></returns>
        public int NumOfUnplacedFruits2(int[] fruits, int[] baskets)
        {
            int len = fruits.Length;
            Int128 mask = 0, unit = 1;
            for (int i = 0, fruit; i < len; i++)
            {
                fruit = fruits[i];
                for (int j = 0; j < len; j++) if ((mask & (unit << j)) == 0 && baskets[j] >= fruit)
                    {
                        mask |= unit << j;
                        break;
                    }
            }

            int bitcnt = 0;
            while (mask > 0) { bitcnt++; mask &= (mask - 1); }
            return len - bitcnt;
        }
    }
}
