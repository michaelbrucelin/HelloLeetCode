using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2418
{
    public class Test2418
    {
        public void Test()
        {
            Interface2418 solution = new Solution2418_api();
            string[] names; int[] heights;
            string[] result, answer;
            int id = 0;

            // 1. 
            names = new string[] { "Mary", "John", "Emma" }; heights = new int[] { 180, 165, 170 };
            answer = new string[] { "Mary", "Emma", "John" };
            result = solution.SortPeople(names, heights);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            names = new string[] { "Alice", "Bob", "Bob" }; heights = new int[] { 155, 185, 150 };
            answer = new string[] { "Bob", "Alice", "Bob" };
            result = solution.SortPeople(names, heights);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            names = new string[] { "GXLVEHVABFOGSFXUYYR", "TUHxnsxmu", "X", "OOYBLVKmzlaeaxbprc", "ARNLAPtfvmutkfsa", "XPMKPDUWOQEEILtbdjip", "QICEutjbr", "R" };
            heights = new int[] { 11578, 89340, 73785, 12096, 55734, 89484, 59775, 72652 };
            answer = new string[] { "XPMKPDUWOQEEILtbdjip", "TUHxnsxmu", "X", "R", "QICEutjbr", "ARNLAPtfvmutkfsa", "OOYBLVKmzlaeaxbprc", "GXLVEHVABFOGSFXUYYR" };
            result = solution.SortPeople(names, heights);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
