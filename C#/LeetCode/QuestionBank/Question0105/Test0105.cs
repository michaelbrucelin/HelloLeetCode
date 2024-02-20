using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0105
{
    public class Test0105
    {
        public void Test()
        {
            Interface0105 solution = new Solution0105_3();
            int[] preorder, inorder;
            IList<int> result, answer; // TreeNode result, answer;
            int id = 0;

            // 1. 
            preorder = new int[] { 3, 9, 20, 15, 7 }; inorder = new int[] { 9, 3, 15, 20, 7 };
            answer = new int[] { 3, 9, 20, int.MinValue, int.MinValue, 15, 7 };
            result = Utils0105.LevelOrder(solution.BuildTree(preorder, inorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            preorder = new int[] { -1 }; inorder = new int[] { -1 };
            answer = new int[] { -1 };
            result = Utils0105.LevelOrder(solution.BuildTree(preorder, inorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            preorder = new int[] { 1, 2 }; inorder = new int[] { 1, 2 };
            answer = new int[] { 1, int.MinValue, 2 };
            result = Utils0105.LevelOrder(solution.BuildTree(preorder, inorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            preorder = new int[] { 3, 2, 1, 4 }; inorder = new int[] { 1, 2, 3, 4 };
            answer = new int[] { 3, 2, 4, 1 };
            result = Utils0105.LevelOrder(solution.BuildTree(preorder, inorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
