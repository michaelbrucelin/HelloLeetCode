using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1995
{
    public class Solution1995_off3 : Interface1995
    {
        public int CountQuadruplets(int[] nums)
        {
            int result = 0, len = nums.Length;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int diff, add; for (int b = len - 3; b >= 1; b--)
            {
                for (int d = b + 2; d < len; d++)
                {
                    diff = nums[d] - nums[b + 1];
                    if (dic.ContainsKey(diff)) dic[diff]++; else dic.Add(diff, 1);
                }
                for (int a = 0; a < b; a++)
                {
                    add = nums[a] + nums[b];
                    if (dic.ContainsKey(add)) result += dic[add];
                }
            }

            return result;
        }
    }
}
