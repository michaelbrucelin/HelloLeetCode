using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3319
{
    public class Test3319
    {
        public void Test()
        {
            Interface3319 solution = new Solution3319_2();
            TreeNode root; int k;
            int result, answer;
            int id = 0;

            // 1. 
            root = new TreeNode(5, new TreeNode(3, new TreeNode(5, new TreeNode(1), new TreeNode(8)), new TreeNode(2)), new TreeNode(6, new TreeNode(5, new TreeNode(6), new TreeNode(8)), new TreeNode(7)));
            k = 2;
            answer = 3;
            result = solution.KthLargestPerfectSubtree(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6), new TreeNode(7)));
            k = 1;
            answer = 7;
            result = solution.KthLargestPerfectSubtree(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            root = new TreeNode(1, new TreeNode(2, null, new TreeNode(4)), new TreeNode(3));
            k = 3;
            answer = -1;
            result = solution.KthLargestPerfectSubtree(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
