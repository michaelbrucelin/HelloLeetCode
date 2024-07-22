using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2101
{
    public class Test2101
    {
        public void Test()
        {
            Interface2101 solution = new Solution2101();
            int[][] bombs;
            int result, answer;
            int id = 0;

            // 1. 
            bombs = [[2, 1, 3], [6, 1, 4]];
            answer = 2;
            result = solution.MaximumDetonation(bombs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            bombs = [[1, 1, 5], [10, 10, 5]];
            answer = 1;
            result = solution.MaximumDetonation(bombs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            bombs = [[1, 2, 3], [2, 3, 1], [3, 4, 2], [4, 5, 3], [5, 6, 4]];
            answer = 5;
            result = solution.MaximumDetonation(bombs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            bombs = [[656, 619, 56], [189, 402, 178], [513, 373, 276], [900, 510, 14], [188, 173, 129], [512, 178, 251], [145, 685, 47],
                     [504, 355, 500], [554, 131, 214], [596, 1, 98], [358, 230, 197], [88, 758, 155], [72, 340, 419], [818, 708, 222]];
            answer = 14;
            result = solution.MaximumDetonation(bombs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            bombs = [[855, 82, 158], [17, 719, 430], [90, 756, 164], [376, 17, 340], [691, 636, 152], [565, 776, 5], [464, 154, 271],
                     [53, 361, 162], [278, 609, 82], [202, 927, 219], [542, 865, 377], [330, 402, 270], [720, 199, 10], [986, 697, 443],
                     [471, 296, 69], [393, 81, 404], [127, 405, 177]];
            answer = 9;
            result = solution.MaximumDetonation(bombs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
