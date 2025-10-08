using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2300
{
    public class Solution2300_2 : Interface2300
    {
        /// <summary>
        /// 排序 + 二分查找
        /// 可以考虑将数组排序改为排序并去重复（记录重复数量），这样可以优化有大量重复数据的场景
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

            long target;
            for (int i = 0, right = m; i < n; i++)
            {
                target = (long)Math.Ceiling(1D * success / spells[_spells[i]]);
                right = BinarySearch(target, Math.Min(right, m - 1));
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

            int BinarySearch(long target, int right)
            {
                int result = m, left = 0, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (potions[mid] >= target)
                    {
                        result = mid; right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                return result;
            }
        }
    }
}
