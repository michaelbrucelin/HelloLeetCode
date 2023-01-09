using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1806
{
    public class Test1806
    {
        public void Test()
        {

        }

        /// <summary>
        /// 眼拙，没看出规律
        /// </summary>
        public void Look4Rules()
        {
            Interface1806 solution = new Solution1806();
            for (int i = 2; i <= 1000; i += 2)
                Console.WriteLine($"{i}\t{solution.ReinitializePermutation(i)}");
        }
    }
}
