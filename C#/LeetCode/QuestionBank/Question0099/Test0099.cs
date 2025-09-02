using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0099
{
    public class Test0099
    {
        public void Test()
        {
            Interface0099 solution = new Solution0099_3();
            TreeNode root;
            TreeNode result, answer;
            IList<int?> _result, _answer;
            int id = 0;

            // 1. 
            root = new TreeNode(1, new TreeNode(3, null, new TreeNode(2)), null);
            _answer = [3, 1, null, null, 2];
            solution.RecoverTree(root);
            _result = tree2list(root);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");

            // 2. 
            root = new TreeNode(3, new TreeNode(1), new TreeNode(4, new TreeNode(2), null));
            _answer = [2, 1, 4, null, null, 3];
            solution.RecoverTree(root);
            _result = tree2list(root);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");

            // 3. 
            root = new TreeNode(2, new TreeNode(3), new TreeNode(1));
            _answer = [2, 1, 3];
            solution.RecoverTree(root);
            _result = tree2list(root);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");
        }

        private List<int?> tree2list(TreeNode root)
        {
            if (root == null) return [null];
            List<int?> result = [];
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            TreeNode item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                if (item == null)
                {
                    result.Add(null);
                }
                else
                {
                    result.Add(item.val); queue.Enqueue(item.left); queue.Enqueue(item.right);
                }
            }
            while (result[^1] == null) result.RemoveAt(result.Count - 1);

            return result;
        }
    }
}
