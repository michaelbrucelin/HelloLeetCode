using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3799
{
    public class Solution3799_2 : Interface3799
    {
        /// <summary>
        /// 回溯
        /// 如果数据量很大，甚至16边形，需要使用回溯，并预处理出每个字母开头的单词列表来优化
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<IList<string>> WordSquares(string[] words)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Array.Sort(words);

            return result;
        }
    }
}
