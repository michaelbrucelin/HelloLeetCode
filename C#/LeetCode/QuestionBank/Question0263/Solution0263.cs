using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0263
{
    public class Solution0263 : Interface0263
    {
        public bool IsUgly(int n)
        {
            if (n <= 0) return false;
            if (n <= 6) return true;

            while ((n & 1) != 1) n >>= 1;
            while (n % 3 == 0) n /= 3;
            while (n % 5 == 0) n /= 5;

            return n == 1;
        }

        /// <summary>
        /// 提交提示“内部错误”，而没有错误的测试用例，怀疑是递归层数太多导致服务器堆栈溢出了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsUgly2(int n)
        {
            if (n <= 0) return false;
            if (n <= 6) return true;

            while ((n & 1) != 1) return IsUgly2(n >> 1);
            while (n % 3 == 0) return IsUgly2(n / 3);
            while (n % 5 == 0) return IsUgly2(n / 5);

            return n == 1;
        }
    }
}
