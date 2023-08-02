using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0822
{
    public class Solution0822 : Interface0822
    {
        /// <summary>
        /// 脑筋急转弯
        /// 去除正反面相同的值后，其余所有值中的最小值就是结果
        /// </summary>
        /// <param name="fronts"></param>
        /// <param name="backs"></param>
        /// <returns></returns>
        public int Flipgame(int[] fronts, int[] backs)
        {
            int len = fronts.Length;
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < len; i++) if (fronts[i] == backs[i]) set.Add(fronts[i]);

            int result = 2001;  // 2001是界外值
            for (int i = 0; i < len; i++)
            {
                if (fronts[i] < result && !set.Contains(fronts[i])) result = fronts[i];
                if (backs[i] < result && !set.Contains(backs[i])) result = backs[i];
            }

            return result != 2001 ? result : 0;
        }
    }
}
