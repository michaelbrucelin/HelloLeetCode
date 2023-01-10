using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0753
{
    public class Solution0753 : Interface0753
    {
        /// <summary>
        /// 题目的意思：
        /// 就是做个最短的字符串，里面n大小的滑动窗口包含全排列，然后k就是可以用的字符
        /// 例如：n = 2, k = 2，k限制了只能用字符"0","1"，n限制了密码的长度，所以一共有4中密码"00","01","10","11"
        ///       "00110"中包含了所有的四种可能，同理"01100", "10011", "11001"也都是正确答案
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string CrackSafe(int n, int k)
        {
            throw new NotImplementedException();
        }
    }
}
