using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2751
{
    public class Test2751
    {
        public void Test()
        {
            Interface2751 solution = new Solution2751();
            int[] positions, healths; string directions;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            positions = [5, 4, 3, 2, 1]; healths = [2, 17, 9, 15, 10]; directions = "RRRRR";
            answer = [2, 17, 9, 15, 10];
            result = solution.SurvivedRobotsHealths(positions, healths, directions);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            positions = [3, 5, 2, 6]; healths = [10, 10, 15, 12]; directions = "RLRL";
            answer = [14];
            result = solution.SurvivedRobotsHealths(positions, healths, directions);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            positions = [1, 2, 5, 6]; healths = [10, 10, 11, 11]; directions = "RLRL";
            answer = [];
            result = solution.SurvivedRobotsHealths(positions, healths, directions);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            positions = [13, 3]; healths = [17, 2]; directions = "LR";
            answer = [16];
            result = solution.SurvivedRobotsHealths(positions, healths, directions);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 5. 
            positions = [11, 44, 16]; healths = [1, 20, 17]; directions = "RLR";
            answer = [18];
            result = solution.SurvivedRobotsHealths(positions, healths, directions);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 6. 
            positions = [4, 46, 50, 25, 16, 45, 47]; healths = [43, 1, 17, 16, 33, 3, 43]; directions = "RLRLRRL";
            answer = [42, 17];
            result = solution.SurvivedRobotsHealths(positions, healths, directions);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
