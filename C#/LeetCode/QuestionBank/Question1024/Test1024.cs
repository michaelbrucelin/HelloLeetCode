using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1024
{
    public class Test1024
    {
        public void Test()
        {
            Interface1024 solution = new Solution1024();
            int[][] clips; int time;
            int result, answer;
            int id = 0;

            // 1. 
            clips = [[0, 2], [4, 6], [8, 10], [1, 9], [1, 5], [5, 9]]; time = 10;
            answer = 3;
            result = solution.VideoStitching(clips, time);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            clips = [[0, 1], [1, 2]]; time = 5;
            answer = -1;
            result = solution.VideoStitching(clips, time);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            clips = [[0, 1], [6, 8], [0, 2], [5, 6], [0, 4], [0, 3], [6, 7], [1, 3], [4, 7], [1, 4], [2, 5], [2, 6], [3, 4], [4, 5], [5, 7], [6, 9]]; time = 9;
            answer = 3;
            result = solution.VideoStitching(clips, time);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            clips = [[1, 1], [0, 2]]; time = 2;
            answer = 1;
            result = solution.VideoStitching(clips, time);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
