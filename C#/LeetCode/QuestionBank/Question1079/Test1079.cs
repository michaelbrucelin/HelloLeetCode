using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1079
{
    public class Test1079
    {
        public void Test()
        {
            Interface1079 solution = new Solution1079_3();
            string tiles;
            int result, answer;
            int id = 0;

            // 1. 
            tiles = "AAB"; answer = 8;
            result = solution.NumTilePossibilities(tiles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            tiles = "AAABBC"; answer = 188;
            result = solution.NumTilePossibilities(tiles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            tiles = "V"; answer = 1;
            result = solution.NumTilePossibilities(tiles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

        }
    }
}
