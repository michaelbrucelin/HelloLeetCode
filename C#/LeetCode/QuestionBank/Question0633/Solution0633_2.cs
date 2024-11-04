using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0633
{
    public class Solution0633_2 : Interface0633
    {
        private static List<int> list = new List<int>();

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool JudgeSquareSum(int c)
        {
            int limit = (int)Math.Sqrt(int.MaxValue);
            if (list.Count == 0) for (int i = 0; i <= limit; i++) list.Add(i * i);

            int pl = 0, pr = list.Count - 1;
            while (pl <= pr)
            {
                if (list[pl] == c || list[pr] == c) return true;
                switch (list[pl] + list[pr] - c)
                {
                    case < 0: pl++; break;
                    case > 0: pr--; break;
                    default: return true;
                }
            }

            return false;
        }
    }
}
