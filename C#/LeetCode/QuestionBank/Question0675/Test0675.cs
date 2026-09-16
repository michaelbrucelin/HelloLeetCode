using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0675
{
    public class Test0675
    {
        public void Test()
        {
            Interface0675 solution = new Solution0675();
            IList<IList<int>> forest;
            int result, answer;
            int id = 0;

            // 1. 
            forest = [[1, 2, 3], [0, 0, 4], [7, 6, 5]];
            answer = 6;
            result = solution.CutOffTree(forest);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            forest = [[1, 2, 3], [0, 0, 0], [7, 6, 5]];
            answer = -1;
            result = solution.CutOffTree(forest);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            forest = [[2, 3, 4], [0, 0, 5], [8, 7, 6]];
            answer = 6;
            result = solution.CutOffTree(forest);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            forest = [[54581641, 64080174, 24346381, 69107959], [86374198, 61363882, 68783324, 79706116], [668150, 92178815, 89819108, 94701471], [83920491, 22724204, 46281641, 47531096], [89078499, 18904913, 25462145, 60813308]];
            answer = 57;
            result = solution.CutOffTree(forest);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
