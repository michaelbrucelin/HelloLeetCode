using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1980
{
    public class Solution1980_2 : Interface1980
    {
        /// <summary>
        /// Hash + 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string FindDifferentBinaryString(string[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (string s in nums) set.Add(Convert.ToInt32(s, 2));

            int n = nums.Length, limit = int.MaxValue;
            for (int i = 0; i < limit; i++) if (!set.Contains(i)) return Convert.ToString(i, 2).PadLeft(n, '0');
            return "";
        }
    }
}
