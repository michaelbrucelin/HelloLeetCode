using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2678
{
    public class Solution2678_api : Interface2678
    {
        public int CountSeniors(string[] details)
        {
            return details.Count(s => int.Parse(s[11..13]) > 60);
        }
    }
}
