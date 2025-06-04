using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3403
{
    public class Test3403
    {
        public void Test()
        {
            Interface3403 solution = new Solution3403();
            string word; int numFriends;
            string result, answer;
            int id = 0;

            // 1. 
            word = "dbca"; numFriends = 2;
            answer = "dbc";
            result = solution.AnswerString(word, numFriends);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            word = "gggg"; numFriends = 4;
            answer = "g";
            result = solution.AnswerString(word, numFriends);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            word = "gh"; numFriends = 1;
            answer = "gh";
            result = solution.AnswerString(word, numFriends);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            word = "aann"; numFriends = 2;
            answer = "nn";
            result = solution.AnswerString(word, numFriends);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            word = "shjtcocathk"; numFriends = 10;
            answer = "th";
            result = solution.AnswerString(word, numFriends);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
