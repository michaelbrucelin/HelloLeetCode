using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0448
{
    public class Solution0448 : Interface0448
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);
            List<int> result = new List<int>();
            for (int i = 1; i <= nums.Length; i++) if (!set.Contains(i)) result.Add(i);

            return result;
        }
    }
}
