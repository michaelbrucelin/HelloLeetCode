using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1092
{
    public class Test1092
    {
        public void Test()
        {
            Interface1092 solution = new Solution1092();
            string str1, str2;
            string result, answer;
            bool correct;
            int id = 0;

            // 1. 
            str1 = "abac"; str2 = "cab"; answer = "cabac";
            result = solution.ShortestCommonSupersequence(str1, str2);
            correct = Utils1092.IsSubSequence(str1, result) && Utils1092.IsSubSequence(str2, result) && result.Length == answer.Length;
            Console.WriteLine($"{++id,2}: {correct + ",",-6} result: {(result, result.Length)}, answer: {(answer, answer.Length)}");

            // 2. 
            str1 = "aaaaaaaa"; str2 = "aaaaaaaa"; answer = "aaaaaaaa";
            result = solution.ShortestCommonSupersequence(str1, str2);
            correct = Utils1092.IsSubSequence(str1, result) && Utils1092.IsSubSequence(str2, result) && result.Length == answer.Length;
            Console.WriteLine($"{++id,2}: {correct + ",",-6} result: {(result, result.Length)}, answer: {(answer, answer.Length)}");

            // 3. 
            str1 = "cbbadddbc"; str2 = "bccddbabbdbbdddc"; answer = "cbccddbabbdbbdddbc";
            result = solution.ShortestCommonSupersequence(str1, str2);
            correct = Utils1092.IsSubSequence(str1, result) && Utils1092.IsSubSequence(str2, result) && result.Length == answer.Length;
            Console.WriteLine($"{++id,2}: {correct + ",",-6} result: {(result, result.Length)}, answer: {(answer, answer.Length)}");

            // 4. 
            str1 = "ddabcaabc"; str2 = "bccddbabbdbbdddc"; answer = "bccddabcaabbdbbdddc";
            result = solution.ShortestCommonSupersequence(str1, str2);
            correct = Utils1092.IsSubSequence(str1, result) && Utils1092.IsSubSequence(str2, result) && result.Length == answer.Length;
            Console.WriteLine($"{++id,2}: {correct + ",",-6} result: {(result, result.Length)}, answer: {(answer, answer.Length)}");

            // 5. 
            str1 = "bddcbbaa"; str2 = "bccddbabbdbbdddc"; answer = "bccddbabbdcbbaadddc";
            result = solution.ShortestCommonSupersequence(str1, str2);
            correct = Utils1092.IsSubSequence(str1, result) && Utils1092.IsSubSequence(str2, result) && result.Length == answer.Length;
            Console.WriteLine($"{++id,2}: {correct + ",",-6} result: {(result, result.Length)}, answer: {(answer, answer.Length)}");
        }
    }
}
