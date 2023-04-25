using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0507
{
    public class Solution0507_api : Interface0507
    {
        /// <summary>
        /// 测试用例num = 99999994，提交超时
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool CheckPerfectNumber(int num)
        {
            return num == Enumerable.Range(1, num - 1)
                                    .Where(i => num % i == 0)
                                    .Distinct()
                                    .Sum();
        }
    }
}
