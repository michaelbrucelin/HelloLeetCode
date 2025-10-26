using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0194
{
    public class Test0194
    {
        public void Test()
        {
            Interface0194 solution = new Solution0194();
            TreeNode root, p, q;
            TreeNode result, answer;
            int id = 0;

            // 1. 
            p = new TreeNode(5) { left = new TreeNode(6), right = new TreeNode(2) { left = new TreeNode(7), right = new TreeNode(4) } };
            q = new TreeNode(1) { left = new TreeNode(0), right = new TreeNode(8) };
            root = new TreeNode(3) { left = p, right = q };
            answer = root;
            result = solution.LowestCommonAncestor(root, p, q);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            q = new TreeNode(4);
            p = new TreeNode(5) { left = new TreeNode(6), right = new TreeNode(2) { left = new TreeNode(7), right = q } };
            root = new TreeNode(3) { left = p, right = new TreeNode(1) { left = new TreeNode(0), right = new TreeNode(8) } };
            answer = p;
            result = solution.LowestCommonAncestor(root, p, q);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
