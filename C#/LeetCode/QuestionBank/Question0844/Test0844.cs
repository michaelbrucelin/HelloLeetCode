using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0844
{
    public class Test0844
    {
        public void Test()
        {
            Interface0844 solution = new Solution0844_3();
            string s, t;
            bool result, answer;
            int id = 0;

            // 1. 
            s = "ab#c"; t = "ad#c"; answer = true;
            result = solution.BackspaceCompare(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "ab##"; t = "c#d#"; answer = true;
            result = solution.BackspaceCompare(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "a#c"; t = "b"; answer = false;
            result = solution.BackspaceCompare(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "bbbextm"; t = "bbb#extm"; answer = false;
            result = solution.BackspaceCompare(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
