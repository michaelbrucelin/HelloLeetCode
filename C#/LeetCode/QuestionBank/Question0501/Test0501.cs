using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0501
{
    public class Test0501
    {
        public void Test()
        {
            Interface0501 solution = new Solution0501_2();
            TreeNode root;
            int[] result, answer;
            int id = 0;

            // 1. 
            root = Utils0501.Str2TreeNode("[1,null,2,2]");
            answer = new int[] { 2 };
            result = solution.FindMode(root);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            root = Utils0501.Str2TreeNode("[0]");
            answer = new int[] { 0 };
            result = solution.FindMode(root);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            root = Utils0501.Str2TreeNode("[6,2,8,0,4,7,9,null,null,2,6]");
            answer = new int[] { 2, 6 };
            result = solution.FindMode(root);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
