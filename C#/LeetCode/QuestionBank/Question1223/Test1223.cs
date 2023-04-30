using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1223
{
    public class Test1223
    {
        public void Test()
        {
            Interface1223 solution = new Solution1223_1_2();
            int n; int[] rollMax;
            int result, answer;
            int id = 0;

            // 1. 
            n = 2; rollMax = new int[] { 1, 1, 2, 2, 2, 3 }; answer = 34;
            result = solution.DieSimulator(n, rollMax);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 2; rollMax = new int[] { 1, 1, 1, 1, 1, 1 }; answer = 30;
            result = solution.DieSimulator(n, rollMax);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 3; rollMax = new int[] { 1, 1, 1, 2, 2, 3 }; answer = 181;
            result = solution.DieSimulator(n, rollMax);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 8; rollMax = new int[] { 1, 2, 3, 4, 5, 6 }; answer = 1366694;
            result = solution.DieSimulator(n, rollMax);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 64; rollMax = new int[] { 10, 11, 12, 13, 14, 15 }; answer = 741496281;
            result = solution.DieSimulator(n, rollMax);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            n = 1000; rollMax = new int[] { 10, 2, 13, 4, 15, 6 }; answer = 675113254;
            result = solution.DieSimulator(n, rollMax);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            n = 5000; rollMax = new int[] { 15, 15, 15, 15, 15, 15 }; answer = 549903798;
            result = solution.DieSimulator(n, rollMax);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
