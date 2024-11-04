using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0633
{
    public class Solution0633 : Interface0633
    {
        private static HashSet<int> set = new HashSet<int>();

        /// <summary>
        /// 哈希表
        /// c是整型，那最多有65535个完全平方数，将这65535个个完全平方数预处理到哈希表中即可
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool JudgeSquareSum(int c)
        {
            int limit = (int)Math.Sqrt(int.MaxValue);
            if (set.Count == 0) for (int i = 0; i <= limit; i++) set.Add(i * i);
            if (set.Contains(c)) return true;
            foreach (int x in set) if (set.Contains(c - x)) return true;

            return false;
        }
    }
}
