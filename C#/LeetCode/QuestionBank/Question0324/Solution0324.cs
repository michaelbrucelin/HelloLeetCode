using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0324
{
    public class Solution0324 : Interface0324
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="nums"></param>
        public void WiggleSort(int[] nums)
        {
            int[] _nums = [.. nums];
            Array.Sort(_nums);
        }
    }
}
