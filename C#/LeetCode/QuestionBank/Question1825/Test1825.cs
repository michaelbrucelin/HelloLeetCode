using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1825
{
    public class Test1825
    {
        public void Test()
        {
            Interface1825 solution;
            int result, answer;
            int id;

            // 1. 
            // ["MKAverage","addElement","addElement","calculateMKAverage","addElement","calculateMKAverage","addElement","addElement","addElement","calculateMKAverage"]
            // [[3,1],[3],[1],[],[10],[],[5],[5],[5],[]]
            id = 0;
            solution = new MKAverage_3(3, 1);
            solution.AddElement(3);
            solution.AddElement(1);
            answer = -1; result = solution.CalculateMKAverage(); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.AddElement(10);
            answer = 3; result = solution.CalculateMKAverage(); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.AddElement(5);
            solution.AddElement(5);
            solution.AddElement(5);
            answer = 5; result = solution.CalculateMKAverage(); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            // ["MKAverage","addElement","addElement","addElement","addElement","addElement","addElement","calculateMKAverage"]
            // [[6,1],[3],[1],[12],[5],[3],[4],[]]
            id = 0; Console.WriteLine();
            solution = new MKAverage_3(6, 1);
            solution.AddElement(3);
            solution.AddElement(1);
            solution.AddElement(12);
            solution.AddElement(5);
            solution.AddElement(3);
            solution.AddElement(4);
            answer = 3; result = solution.CalculateMKAverage(); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
