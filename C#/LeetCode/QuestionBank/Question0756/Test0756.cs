using LeetCode.QuestionBank.Question0432;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0756
{
    public class Test0756
    {
        public void Test()
        {
            Interface0756 solution = new Solution0756_2();
            string bottom; IList<string> allowed;
            bool result, answer;
            int id = 0;

            // 1. 
            bottom = "BCD"; allowed = ["BCC", "CDE", "CEA", "FFF"];
            answer = true;
            result = solution.PyramidTransition(bottom, allowed);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            bottom = "AAAA"; allowed = ["AAB", "AAC", "BCD", "BBE", "DEF"];
            answer = false;
            result = solution.PyramidTransition(bottom, allowed);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            bottom = "ABCD"; allowed = ["ABC", "BCA", "CDA", "ABD", "BCE", "CDF", "DEA", "EFF", "AFF"];
            answer = true;
            result = solution.PyramidTransition(bottom, allowed);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            bottom = "BBDCDA";
            allowed = ["CAB", "ACB", "ACA", "AAA", "AAC", "AAB", "CDB", "BCA", "CBB", "BCC", "BAB", "BAC", "BAA", "CCD", "CAA", "CCA", "CCC", "CCB", "DAD", "DAA", "DAC", "ACD", "DCB", "DCC", "DCA",
                       "CAD", "ACC", "ABA", "ABB", "ABD", "BBD", "BBB", "BBA", "ADD", "ADB", "ADC", "DDC", "DDB", "DDA", "DDD", "CDD", "CBC", "CBA", "CDA", "CBD", "CDC", "DBC", "DBD", "BDA"];
            answer = true;
            result = solution.PyramidTransition(bottom, allowed);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
