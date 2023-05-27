using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1995
{
    public class Solution1995_off2 : Interface1995
    {
        public int CountQuadruplets(int[] nums)
        {
            int result = 0, len = nums.Length;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int add; for (int c = len - 2; c >= 2; c--)
            {
                if (dic.ContainsKey(nums[c + 1])) dic[nums[c + 1]]++; else dic.Add(nums[c + 1], 1);
                for (int a = 0; a < c - 1; a++) for (int b = a + 1; b < c; b++)
                    {
                        add = nums[a] + nums[b] + nums[c];
                        if (dic.ContainsKey(add)) result += dic[add];
                    }
            }

            return result;
        }
    }
}
