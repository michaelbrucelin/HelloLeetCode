using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1980
{
    public class Solution1980 : Interface1980
    {
        /// <summary>
        /// Hash + 回溯
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string FindDifferentBinaryString(string[] nums)
        {
            HashSet<string> set = [.. nums, ""];
            int n = nums.Length;
            char[] buffer = new char[n];
            return backtrack(0);

            string backtrack(int idx)
            {
                string s;
                if (idx == n) return set.Contains(s = new string(buffer)) ? "" : s;

                buffer[idx] = '0';
                if (!set.Contains(s = backtrack(idx + 1))) return s;
                buffer[idx] = '1';
                return backtrack(idx + 1);
            }
        }
    }
}
