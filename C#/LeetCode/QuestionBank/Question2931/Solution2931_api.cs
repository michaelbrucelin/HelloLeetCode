using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2931
{
    public class Solution2931_api : Interface2931
    {
        /// <summary>
        /// 逻辑同Solution2931，改为Linq实现
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public long MaxSpending(int[][] values)
        {
            return values.SelectMany(arr => arr).OrderBy(x => x).Select((val, idx) => ((long)val, idx + 1)).Sum(t => t.Item1 * t.Item2);
        }
    }
}
