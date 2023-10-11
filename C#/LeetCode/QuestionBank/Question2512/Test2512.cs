using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2512
{
    public class Test2512
    {
        public void Test()
        {
            Interface2512 solution = new Solution2512_2();
            string[] positive_feedback, negative_feedback, report; int[] student_id; int k;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            positive_feedback = new string[] { "smart", "brilliant", "studious" };
            negative_feedback = new string[] { "not" };
            report = new string[] { "this student is studious", "the student is smart" };
            student_id = new int[] { 1, 2 };
            k = 2;
            answer = new int[] { 1, 2 };
            result = solution.TopStudents(positive_feedback, negative_feedback, report, student_id, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            positive_feedback = new string[] { "smart", "brilliant", "studious" };
            negative_feedback = new string[] { "not" };
            report = new string[] { "this student is not studious", "the student is smart" };
            student_id = new int[] { 1, 2 };
            k = 2;
            answer = new int[] { 2, 1 };
            result = solution.TopStudents(positive_feedback, negative_feedback, report, student_id, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
