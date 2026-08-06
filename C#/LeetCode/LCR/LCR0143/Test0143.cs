using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0143
{
    public class Test0143
    {
        public void Test()
        {
            Interface0143 solution = new Solution0143();
            TreeNode A, B;
            bool result, answer;
            int id = 0;

            // 1. 
            A = new TreeNode(1, new TreeNode(7), new TreeNode(5)); B = new TreeNode(6, new TreeNode(1));
            answer = false;
            result = solution.IsSubStructure(A, B);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            A = new TreeNode(3, new TreeNode(6, new TreeNode(1), new TreeNode(8)), new TreeNode(7)); B = new TreeNode(6, new TreeNode(1));
            answer = true;
            result = solution.IsSubStructure(A, B);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            A = new TreeNode(1, new TreeNode(0, new TreeNode(-4), new TreeNode(-3)), new TreeNode(1)); B = new TreeNode(1, new TreeNode(-4));
            answer = true;
            result = solution.IsSubStructure(A, B);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            A = new TreeNode(-1, new TreeNode(3, new TreeNode(0)), new TreeNode(2)); B = null;
            answer = false;
            result = solution.IsSubStructure(A, B);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            A = null; B = null;
            answer = false;
            result = solution.IsSubStructure(A, B);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            A = new TreeNode(10, new TreeNode(12, new TreeNode(8), new TreeNode(3)), new TreeNode(6, new TreeNode(11))); B = new TreeNode(10, new TreeNode(12, new TreeNode(8)), new TreeNode(6));
            answer = true;
            result = solution.IsSubStructure(A, B);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            A = new TreeNode(1, new TreeNode(0, new TreeNode(-4), new TreeNode(-3)), new TreeNode(1)); B = new TreeNode(1, new TreeNode(-4));
            answer = false;
            result = solution.IsSubStructure(A, B);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
