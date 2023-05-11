using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1015
{
    public class Solution1015 : Interface1015
    {
        /// <summary>
        /// 模拟乘法
        /// 具体分析见Solution1015.md
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SmallestRepunitDivByK(int k)
        {
            if ((k & 1) != 1 || k % 10 == 5) return -1;


            throw new NotImplementedException();
        }
    }
}
