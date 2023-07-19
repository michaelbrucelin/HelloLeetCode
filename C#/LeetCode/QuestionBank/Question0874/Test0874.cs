using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0874
{
    public class Test0874
    {
        public void Test()
        {
            Interface0874 solution = new Solution0874_2();
            int[] commands; int[][] obstacles;
            int result, answer;
            int id = 0;

            // 1. 
            commands = new int[] { 4, -1, 3 }; obstacles = new int[0][];
            answer = 25;
            result = solution.RobotSim(commands, obstacles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            commands = new int[] { 4, -1, 4, -2, 4 }; obstacles = new int[][] { new int[] { 2, 4 } };
            answer = 65;
            result = solution.RobotSim(commands, obstacles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            commands = new int[] { 6, -1, -1, 6 }; obstacles = new int[0][];
            answer = 36;
            result = solution.RobotSim(commands, obstacles);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
