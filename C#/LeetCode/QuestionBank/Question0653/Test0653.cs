using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0653
{
    public class Test0653
    {
        public void Test()
        {
            Interface0653 solution = new Solution0653_3();
            TreeNode root; int k;
            bool result, answer;
            int id = 0;

            // 1. 
            // root = [5,3,6,2,4,null,7], k = 9
            root = new TreeNode(5) { left = new TreeNode(3) { left = new TreeNode(2), right = new TreeNode(4) }, right = new TreeNode(6) { right = new TreeNode(7) } };
            k = 9; answer = true;
            result = solution.FindTarget(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            // root = [5,3,6,2,4,null,7], k = 28
            k = 28; answer = false;
            result = solution.FindTarget(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            // root = [2,1,3], k = 9
            root = new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) };
            k = 9; answer = false;
            result = solution.FindTarget(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            // root = [2,1,3], k = 1
            k = 1; answer = false;
            result = solution.FindTarget(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            // root = [2,1,3], k = 3
            k = 3; answer = true;
            result = solution.FindTarget(root, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
