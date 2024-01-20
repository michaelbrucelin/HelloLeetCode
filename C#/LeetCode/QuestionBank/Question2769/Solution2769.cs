using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2769
{
    public class Solution2769 : Interface2769
    {
        public int TheMaximumAchievableX(int num, int t)
        {
            return num + (t << 1);
        }
    }
}
