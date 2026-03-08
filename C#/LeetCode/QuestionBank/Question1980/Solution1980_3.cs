using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1980
{
    public class Solution1980_3 : Interface1980
    {
        private static readonly Random rand = new Random();

        /// <summary>
        /// Hash + 随机化
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string FindDifferentBinaryString(string[] nums)
        {
            HashSet<string> set = [.. nums, ""];
            int n = nums.Length, limit = 1 << n;
            string s = "";
            while (set.Contains(s)) s = Convert.ToString(rand.Next(0, limit), 2).PadLeft(n, '0');

            return s;
        }
    }
}
