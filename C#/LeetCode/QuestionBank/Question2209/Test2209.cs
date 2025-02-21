using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2209
{
    public class Test2209
    {
        public void Test()
        {
            Interface2209 solution = new Solution2209();
            string floor; int numCarpets, carpetLen;
            int result, answer;
            int id = 0;

            // 1. 
            floor = "10110101"; numCarpets = 2; carpetLen = 2;
            answer = 2;
            result = solution.MinimumWhiteTiles(floor, numCarpets, carpetLen);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            floor = "11111"; numCarpets = 2; carpetLen = 3;
            answer = 0;
            result = solution.MinimumWhiteTiles(floor, numCarpets, carpetLen);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            floor = "100011111001110111111110001100011101111011111111111001001011"; numCarpets = 2; carpetLen = 3;
            answer = 35;
            result = solution.MinimumWhiteTiles(floor, numCarpets, carpetLen);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
