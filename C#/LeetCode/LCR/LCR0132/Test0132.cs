using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0132
{
    public class Test0132
    {
        public void Test()
        {
            Interface0132 solution = new Solution0132_2();
            int bamboo_len;
            int result, answer;
            int id = 0;

            // 1. 
            bamboo_len = 12;
            answer = 81;
            result = solution.CuttingBamboo(bamboo_len);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            bamboo_len = 1000;
            answer = 620946522;
            result = solution.CuttingBamboo(bamboo_len);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
