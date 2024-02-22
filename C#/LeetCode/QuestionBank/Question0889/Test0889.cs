using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0889
{
    public class Test0889
    {
        public void Test()
        {
            Interface0889 solution = new Solution0889_2();
            int[] preorder, postorder;
            IList<int> result, answer; // TreeNode result, answer;
            int id = 0;

            // 1. 
            preorder = new int[] { 1, 2, 4, 5, 3, 6, 7 }; postorder = new int[] { 4, 5, 2, 6, 7, 3, 1 };
            answer = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            result = Utils0889.LevelOrder(solution.ConstructFromPrePost(preorder, postorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            preorder = new int[] { 1 }; postorder = new int[] { 1 };
            answer = new int[] { 1 };
            result = Utils0889.LevelOrder(solution.ConstructFromPrePost(preorder, postorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            preorder = new int[] { 3, 9, 20, 15, 7 }; postorder = new int[] { 9, 15, 7, 20, 3 };
            answer = new int[] { 3, 9, 20, int.MinValue, int.MinValue, 15, 7 };
            result = Utils0889.LevelOrder(solution.ConstructFromPrePost(preorder, postorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            preorder = new int[] { 1, 2 }; postorder = new int[] { 2, 1 };
            answer = new int[] { 1, 2 };
            result = Utils0889.LevelOrder(solution.ConstructFromPrePost(preorder, postorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 5. 
            preorder = new int[] { 3, 2, 1, 4 }; postorder = new int[] { 1, 2, 4, 3 };
            answer = new int[] { 3, 2, 4, 1 };
            result = Utils0889.LevelOrder(solution.ConstructFromPrePost(preorder, postorder));
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
