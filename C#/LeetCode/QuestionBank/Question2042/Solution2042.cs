using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2042
{
    public class Solution2042 : Interface2042
    {
        public bool AreNumbersAscending(string s)
        {
            int[] nums = s.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => StrToInt(s, -1))
                            .Where(i => i >= 0)
                            .ToArray();

            for (int i = 1; i < nums.Length; i++)
                if (nums[i - 1] >= nums[i]) return false;

            return true;
        }

        private static int StrToInt(string s, int @default)
        {
            int num;
            if (int.TryParse(s, out num))
                return num;
            return @default;
        }
    }
}
