using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1678
{
    public class Solution1678_api : Interface1678
    {
        public string Interpret(string command)
        {
            return command.Replace("(al)", "al").Replace("()", "o");
        }
    }
}
