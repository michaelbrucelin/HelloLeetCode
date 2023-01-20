using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0258
{
    public class Solution0258_3 : Interface0258
    {
        public int AddDigits(int num)
        {
            return (num - 1) % 9 + 1;
        }
    }
}
