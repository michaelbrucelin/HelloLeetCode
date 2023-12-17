using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2788
{
    public class Solution2788_api : Interface2788
    {
        public IList<string> SplitWordsBySeparator(IList<string> words, char separator)
        {
            return words.SelectMany(word => word.Split(separator, StringSplitOptions.RemoveEmptyEntries)).ToArray();
        }
    }
}
