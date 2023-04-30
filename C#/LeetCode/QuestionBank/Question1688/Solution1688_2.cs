using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1688
{
    public class Solution1688_2 : Interface1688
    {
        /// <summary>
        /// 数学
        /// 无论n是偶数还是奇数，都是一次配对淘汰一次队伍，一共需要淘汰n-1支队伍，所以结果是n-1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumberOfMatches(int n)
        {
            return n - 1;
        }
    }
}
