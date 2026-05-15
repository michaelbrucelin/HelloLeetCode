using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1713
{
    public class Solution1713 : Interface1713
    {
        /// <summary>
        ///  Trie + 回溯
        ///  1. 将dictionary中的词汇放到Trie中，注意如果词汇长度大于sentence的长度，丢弃
        ///  2. 找出sentence中所有词汇的区间
        ///  3. 基于2的结果DFS，回溯，BFS都可以找出结果
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public int Respace(string[] dictionary, string sentence)
        {
            throw new NotImplementedException();
        }
    }
}
