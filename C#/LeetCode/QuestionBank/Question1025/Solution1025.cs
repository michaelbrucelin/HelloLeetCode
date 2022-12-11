using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1025
{
    public class Solution1025 : Interface1025
    {
        /// <summary>
        /// 逻辑思维题
        /// n为偶数，爱丽丝每次都取1即可，取完后n变为奇数，鲍勃无论怎样取，n都会变回偶数，所以爱丽丝继续取1，就获胜了
        /// n为奇数，爱丽丝无论怎么获取，取完后n都会变为偶数，那么鲍勃只要每次都获取1，爱丽丝必输
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool DivisorGame(int n)
        {
            return (n & 1) == 0;
        }
    }
}
