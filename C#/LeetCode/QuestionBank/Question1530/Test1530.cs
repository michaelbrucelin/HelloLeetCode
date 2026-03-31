using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1530
{
    public class Test1530
    {
        public void Test()
        {
            Interface1530 solution = new Solution1530();
            TreeNode root; int distance;
            int result, answer;
            int id = 0;

            // 1. 
            root = new TreeNode(1, new TreeNode(2, null, new TreeNode(4)), new TreeNode(3));
            distance = 3;
            answer = 1;
            result = solution.CountPairs(root, distance);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6), new TreeNode(7)));
            distance = 3;
            answer = 2;
            result = solution.CountPairs(root, distance);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            root = new TreeNode(7, new TreeNode(1, new TreeNode(6)), new TreeNode(4, new TreeNode(5), new TreeNode(3, null, new TreeNode(2))));
            distance = 3;
            answer = 1;
            result = solution.CountPairs(root, distance);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            root = new TreeNode(100);
            distance = 1;
            answer = 0;
            result = solution.CountPairs(root, distance);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            root = new TreeNode(1, new TreeNode(1), new TreeNode(1));
            distance = 2;
            answer = 1;
            result = solution.CountPairs(root, distance);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
