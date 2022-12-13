using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1832
{
    public class Solution1832_2 : Interface1832
    {
        /// <summary>
        /// 与Solution1832一样，但是将HashSet改为数组，理论上可以更快
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public bool CheckIfPangram(string sentence)
        {
            bool[] helper = new bool[26];
            for (int i = 0; i < sentence.Length; i++)
                helper[sentence[i] - 'a'] = true;

            return helper.All(b => b);
        }
    }
}
