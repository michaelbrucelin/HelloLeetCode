using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0056
{
    public class Test0056
    {
        public void Test()
        {
            Interface0056 solution = new Solution0056_3_2();
            TreeNode root; int k;
            bool result, answer;
            int id = 0;

            // 1. 
            root = new TreeNode(8, new TreeNode(6, new TreeNode(5), new TreeNode(7)), new TreeNode(10, new TreeNode(9), new TreeNode(11)));
            k = 12;
            answer = true;
            result = solution.FindTarget(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            root = new TreeNode(8, new TreeNode(6, new TreeNode(5), new TreeNode(7)), new TreeNode(10, new TreeNode(9), new TreeNode(11)));
            k = 22;
            answer = false;
            result = solution.FindTarget(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
