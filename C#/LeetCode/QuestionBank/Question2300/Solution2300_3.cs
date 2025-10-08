using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2300
{
    public class Solution2300_3 : Interface2300
    {
        /// <summary>
        /// 排序 + 双指针
        /// 逻辑同Solution2300_2，将二分查找改为双指针
        /// </summary>
        /// <param name="spells"></param>
        /// <param name="potions"></param>
        /// <param name="success"></param>
        /// <returns></returns>
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            int n = spells.Length, m = potions.Length;
            int[] result = new int[n];

            int[] _spells = new int[n];
            for (int i = 0; i < n; i++) _spells[i] = i;
            Array.Sort(_spells, (x, y) => spells[x] - spells[y]);
            Array.Sort(potions);
            if (1L * spells[_spells[^1]] * potions[^1] < success) return result;

            for (int i = 0, right = m; i < n; i++)
            {
                while (right > 0 && 1L * spells[_spells[i]] * potions[right - 1] >= success) right--;
                if (right > 0)
                {
                    result[_spells[i]] = m - right;
                }
                else
                {
                    for (int j = i; j < n; j++) result[_spells[j]] = m;
                    break;
                }
            }

            return result;
        }
    }
}
