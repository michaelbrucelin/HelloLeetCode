using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1672
{
    public class Solution1672_api : Interface1672
    {
        public int MaximumWealth(int[][] accounts)
        {
            return accounts.Select(arr => arr.Sum()).Max();
        }
    }
}
