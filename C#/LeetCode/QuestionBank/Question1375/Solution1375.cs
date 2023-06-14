using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1375
{
    public class Solution1375 : Interface1375
    {
        /// <summary>
        /// 哈希
        /// 数组的前n项是1-n的一个排列，那就是一个结果
        /// </summary>
        /// <param name="flips"></param>
        /// <returns></returns>
        public int NumTimesAllBlue(int[] flips)
        {
            int result = 0;
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < flips.Length; i++)
            {
                if (flips[i] != i + 1)
                {
                    if (set.Contains(i + 1)) set.Remove(i + 1); else set.Add(i + 1);
                    if (set.Contains(flips[i])) set.Remove(flips[i]); else set.Add(flips[i]);
                }
                if (set.Count == 0) result++;
            }

            return result;
        }
    }
}
