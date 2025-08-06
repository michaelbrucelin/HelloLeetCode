using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3602
{
    public class Solution3602_api : Interface3602
    {
        /// <summary>
        /// 36不是有效的参数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string ConcatHex36(int n)
        {
            return $"{Convert.ToString(n * n, 16)}{Convert.ToString(n * n * n, 36)}";
        }
    }
}
