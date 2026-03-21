using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0124
{
    public class Test0124
    {
        public void Test()
        {
            Interface0124 solution = new Solution0124();
            TreeNode root;
            int result, answer;
            int id = 0;

            // 1. 
            root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            answer = 6;
            result = solution.MaxPathSum(root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            root = new TreeNode(-10, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            answer = 42;
            result = solution.MaxPathSum(root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            root = new TreeNode(5, new TreeNode(4, new TreeNode(11, new TreeNode(7), new TreeNode(2))), new TreeNode(8, new TreeNode(13), new TreeNode(4, null, new TreeNode(1))));
            answer = 48;
            result = solution.MaxPathSum(root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
