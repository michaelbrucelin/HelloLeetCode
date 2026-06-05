using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0034
{
    public class Test0034
    {
        public void Test()
        {
            Interface0034 solution = new Solution0034();
            TreeNode root; int k;
            int result, answer;
            int id = 0;

            // 1. 
            root = new TreeNode(5) { left = new TreeNode(2) { left = new TreeNode(4) }, right = new TreeNode(3) };
            k = 2;
            answer = 12;
            result = solution.MaxValue(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            root = new TreeNode(4) { left = new TreeNode(1) { left = new TreeNode(9) }, right = new TreeNode(3) { right = new TreeNode(2) } };
            k = 2;
            answer = 16;
            result = solution.MaxValue(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
