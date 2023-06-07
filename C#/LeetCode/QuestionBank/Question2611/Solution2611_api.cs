using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2611
{
    public class Solution2611_api : Interface2611
    {
        public int MiceAndCheese(int[] reward1, int[] reward2, int k)
        {
            return reward2.Sum() + reward1.Zip(reward2, (i1, i2) => i1 - i2).OrderByDescending(i => i).Take(k).Sum();
        }

        public int MiceAndCheese2(int[] reward1, int[] reward2, int k)
        {
            return reward2.Sum() + reward1.Zip(reward2).Select(t => t.First - t.Second).OrderByDescending(i => i).Take(k).Sum();
        }
    }
}
