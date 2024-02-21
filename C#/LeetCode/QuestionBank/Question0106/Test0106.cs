using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0106
{
    public class Test0106
    {
        public void Test()
        {
            Interface0106 solution = new Solution0106_2();
            int[] inorder, postorder;
            IList<int> result, answer; // TreeNode result, answer;
            int id = 0;

            // 1. 
            inorder = new int[] { 9, 3, 15, 20, 7 }; postorder = new int[] { 9, 15, 7, 20, 3 };
            answer = new int[] { 3, 9, 20, int.MinValue, int.MinValue, 15, 7 };
            result = Utils0106.LevelOrder(solution.BuildTree(inorder, postorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            inorder = new int[] { -1 }; postorder = new int[] { -1 };
            answer = new int[] { -1 };
            result = Utils0106.LevelOrder(solution.BuildTree(inorder, postorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            inorder = new int[] { 1, 2 }; postorder = new int[] { 2, 1 };
            answer = new int[] { 1, int.MinValue, 2 };
            result = Utils0106.LevelOrder(solution.BuildTree(inorder, postorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            inorder = new int[] { 1, 2, 3, 4 }; postorder = new int[] { 1, 2, 4, 3 };
            answer = new int[] { 3, 2, 4, 1 };
            result = Utils0106.LevelOrder(solution.BuildTree(inorder, postorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
